using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; // 캐릭터 이동 속도
    private Rigidbody2D rb;
    private bool isFallen = false; // 캐릭터가 쓰러졌는지 여부

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 캐릭터가 쓰러지지 않았을 때만 움직임 허용
        if (!isFallen)
        {
            // A 키와 D 키로 이동 제어
            if (Input.GetKey(KeyCode.A)) // A 키를 누르면 왼쪽으로 이동
            {
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D)) // D 키를 누르면 오른쪽으로 이동
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) // 공과 충돌
        {
            Debug.Log("Player hit by the ball!");

            isFallen = true;

            // Rigidbody 2D Constraints 해제하여 회전 허용
            rb.constraints = RigidbodyConstraints2D.None;

            // 랜덤한 방향으로 힘을 추가
            Vector2 fallForce = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rb.AddForce(fallForce * 2f, ForceMode2D.Impulse);

            Invoke(nameof(FreezeAfterFall), 1f); // 1초 후 고정
        }
    }

    private void FreezeAfterFall()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
