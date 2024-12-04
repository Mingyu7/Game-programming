using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public float bounceForce = 10f; // 공이 튕기는 힘
    private Rigidbody2D rb;

    void Start()
    {
        // Rigidbody 2D 컴포넌트를 가져옵니다.
        rb = GetComponent<Rigidbody2D>();

        // 초기 속도를 아래 방향으로 설정
        Vector2 initialDirection = new Vector2(0, -1).normalized; // 아래 방향
        rb.velocity = initialDirection * bounceForce;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌한 오브젝트의 태그 확인
        Vector2 bounceDirection = Vector2.zero;

        if (collision.CompareTag("Player"))
        {
            // 플레이어와의 충돌: 항상 위쪽으로 튕기게 설정
            bounceDirection = (transform.position - collision.transform.position).normalized;
            bounceDirection.y = Mathf.Abs(bounceDirection.y); // 위로 튕기도록 보정
        }
        else if (collision.CompareTag("Wall"))
        {
            // 벽과의 충돌: 벽의 위치를 기반으로 반사 방향 계산
            if (collision.transform.position.y > transform.position.y) // 위쪽 벽에 닿음
            {
                bounceDirection = new Vector2(rb.velocity.x, -Mathf.Abs(rb.velocity.y)).normalized; // 아래로 튕김
            }
            else if (collision.transform.position.x < transform.position.x) // 왼쪽 벽에 닿음
            {
                bounceDirection = new Vector2(1, rb.velocity.y).normalized; // 오른쪽으로 튕김
            }
            else if (collision.transform.position.x > transform.position.x) // 오른쪽 벽에 닿음
            {
                bounceDirection = new Vector2(-1, rb.velocity.y).normalized; // 왼쪽으로 튕김
            }
        }
        else if (collision.gameObject.name == "wall_floor_1") // 왼쪽 아래 벽
        {
            // 오른쪽 플레이어 점수 증가
            ScoreManager.Instance.AddRightScore(1);

            // 공 삭제
            Destroy(gameObject);
        }
        else if (collision.gameObject.name == "wall_floor_2") // 오른쪽 아래 벽
        {
            // 왼쪽 플레이어 점수 증가
            ScoreManager.Instance.AddLeftScore(1);

            // 공 삭제
            Destroy(gameObject);
        }

        // 새로운 힘 적용
        if (bounceDirection != Vector2.zero)
        {
            ApplyBounce(bounceDirection);
        }
    }

    private void ApplyBounce(Vector2 direction)
    {
        // 공의 속도 재설정
        rb.velocity = Vector2.zero; // 기존 속도 제거
        rb.AddForce(direction * bounceForce, ForceMode2D.Impulse); // 새로운 힘 적용
    }
}