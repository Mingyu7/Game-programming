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
            // 벽과의 충돌: 반사 벡터 계산
            Vector2 normal = collision.ClosestPoint(transform.position) - (Vector2)transform.position;
            bounceDirection = normal.normalized;
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