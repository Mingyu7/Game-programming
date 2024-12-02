using UnityEngine;

public class WallReflection : MonoBehaviour
{
    public float bounceForce = 10f; // 공이 튕기는 힘

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 공과의 충돌 확인
        if (collision.CompareTag("Ball"))
        {
            // 공의 Rigidbody 가져오기
            Rigidbody2D ballRb = collision.GetComponent<Rigidbody2D>();
            if (ballRb != null)
            {
                // 아래쪽으로 튕기도록 반사 방향 고정
                Vector2 bounceDirection = new Vector2(0, -1).normalized;

                // 기존 속도 제거 후 새로운 힘 적용
                ballRb.velocity = Vector2.zero; // 기존 속도 제거
                ballRb.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse); // 아래로 힘 적용

                // 디버그 메시지 출력
                Debug.Log("Ball hit wall and bounced down.");
            }
        }
    }
}
