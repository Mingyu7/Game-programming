using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; // ìºë¦­?„° ?´?™ ?†?„
    private Rigidbody2D rb;
    private bool isFallen = false; // ìºë¦­?„°ê°? ?“°?Ÿ¬ì¡ŒëŠ”ì§? ?—¬ë¶?

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ìºë¦­?„°ê°? ?“°?Ÿ¬ì§?ì§? ?•Š?•˜?„ ?•Œë§? ???ì§ì„ ?—ˆ?š©
        if (!isFallen)
        {
            // A ?‚¤??? D ?‚¤ë¡? ?´?™ ? œ?–´
            if (Input.GetKey(KeyCode.A)) // A ?‚¤ë¥? ?ˆ„ë¥´ë©´ ?™¼ìª½ìœ¼ë¡? ?´?™
            {
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D)) // D ?‚¤ë¥? ?ˆ„ë¥´ë©´ ?˜¤ë¥¸ìª½?œ¼ë¡? ?´?™
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
