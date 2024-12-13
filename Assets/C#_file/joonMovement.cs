using UnityEngine;

public class joonMovement : MonoBehaviour
{
    public float speed = 5f; // 이동 속도
    private bool canMove = true; // 이동 가능 여부
    private Rigidbody2D rb; // Rigidbody2D 컴포넌트
    public float forcePush = 5f; // 벽에 충돌 시 밀어내는 힘

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canMove)
        {
            // 왼쪽 화살표 키를 눌렀을 때 좌측으로 이동
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                MoveCharacter(Vector2.left);
            }
            // 오른쪽 화살표 키를 눌렀을 때 우측으로 이동
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                MoveCharacter(Vector2.right);
            }
            else
            {
                // 방향키를 누르지 않으면 이동 멈춤
                StopCharacter();
            }
        }
    }

    // 캐릭터를 물리적으로 이동시키는 함수
    private void MoveCharacter(Vector2 direction)
    {
        // 수직 속도를 0으로 유지하여 위로 올라가는 현상을 방지
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }

    // 캐릭터를 멈추는 함수
    private void StopCharacter()
    {
        // 수평 속도를 0으로 설정하여 멈추게 함
        rb.velocity = new Vector2(0f, rb.velocity.y);
    }

    // 벽에 충돌했을 때 호출되는 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            canMove = false; // 벽에 충돌했을 때 이동을 멈춤
            rb.velocity = Vector2.zero; // 이동을 멈춤

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
            // 벽에 부딪혔을 때 반대 방향으로 잠시 밀기
            // 벽과 겹치는 것을 방지하기 위해 강제로 밀어낸다
            Vector2 pushDirection = (transform.position - collision.transform.position).normalized; // 벽에서 벗어나는 방향 계산
            rb.velocity = new Vector2(0f, rb.velocity.y); // 수평 속도 0, 수직 속도 유지
            rb.AddForce(pushDirection * forcePush, ForceMode2D.Impulse); // 벽에서 밀어내기
        }
    }

    // 벽에서 벗어났을 때 호출되는 함수
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            canMove = true; // 벽에서 벗어났을 때 이동 가능 상태로 변경
        }
    }
}
