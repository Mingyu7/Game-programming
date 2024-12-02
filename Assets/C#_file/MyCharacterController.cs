using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; // 캐릭터 이동 속도
    private Rigidbody2D rb;

    public KeyCode leftKey;  // 왼쪽 이동 키
    public KeyCode rightKey; // 오른쪽 이동 키

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Z축 회전 고정
    }

    void FixedUpdate()
    {
        float moveInput = 0f;

        if (Input.GetKey(leftKey))
        {
            moveInput = -1f; // 왼쪽 이동
        }
        else if (Input.GetKey(rightKey))
        {
            moveInput = 1f; // 오른쪽 이동
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
}
