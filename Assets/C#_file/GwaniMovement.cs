using UnityEngine;

public class GwaniMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 캐릭터 이동 속도
    private Rigidbody2D rb;
    private bool canMove = true; // 캐릭터의 이동 가능 여부
    public float forcePush = 5f; // 벽에 충돌 시 밀어내는 힘

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 벽에 부딪히지 않으면 이동 가능
        if (canMove)
        {
            // A 키를 눌렀을 때 왼쪽으로 이동
            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y); // 좌측 이동
            }
            // D 키를 눌렀을 때 오른쪽으로 이동
            else if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y); // 우측 이동
            }
            else
            {
                // 이동하지 않으면 속도를 0으로 설정
                rb.velocity = new Vector2(0f, rb.velocity.y);
            }
        }
    }

    // 벽에 충돌했을 때 호출되는 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            canMove = false; // 벽에 충돌했을 때 이동을 멈춤
            rb.velocity = Vector2.zero; // 수평 이동 속도 0으로 설정

            // 벽과의 충돌을 강제로 밀어내기 (강제 밀기)
            Vector2 pushDirection = (transform.position - collision.transform.position).normalized; // 벽에서 벗어나는 방향 계산
            rb.AddForce(pushDirection * forcePush, ForceMode2D.Impulse); // 벽에서 밀어내기
        }
    }

    // 벽과 계속 충돌하고 있을 때 호출되는 함수
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // 벽에 부딪혔을 때 캐릭터가 벽에 끼지 않도록 밀어내기
            Vector2 pushDirection = (transform.position - collision.transform.position).normalized; // 벽에서 벗어나는 방향 계산
            rb.velocity = new Vector2(0f, rb.velocity.y); // 수평 속도 0으로 설정, 수직 속도 유지
            rb.AddForce(pushDirection * forcePush, ForceMode2D.Impulse); // 벽에서 밀어내기
        }
    }

    // 벽에서 벗어났을 때 호출되는 함수
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            canMove = true; // 벽에서 벗어나면 이동 가능 상태로 변경
        }
    }
}
