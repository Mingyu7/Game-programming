using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; // 캐릭?�� ?��?�� ?��?��
    private Rigidbody2D rb;
    private bool isFallen = false; // 캐릭?���? ?��?��졌는�? ?���?

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 캐릭?���? ?��?���?�? ?��?��?�� ?���? ???직임 ?��?��
        if (!isFallen)
        {
            // A ?��??? D ?���? ?��?�� ?��?��
            if (Input.GetKey(KeyCode.A)) // A ?���? ?��르면 ?��쪽으�? ?��?��
            {
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D)) // D ?���? ?��르면 ?��른쪽?���? ?��?��
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
        }
    }

    

    private void FreezeAfterFall()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
