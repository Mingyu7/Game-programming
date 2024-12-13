using UnityEngine;

public class GwaniMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // ĳ���� �̵� �ӵ�
    private Rigidbody2D rb;
    private bool canMove = true; // ĳ������ �̵� ���� ����
    public float forcePush = 5f; // ���� �浹 �� �о�� ��

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ���� �ε����� ������ �̵� ����
        if (canMove)
        {
            // A Ű�� ������ �� �������� �̵�
            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y); // ���� �̵�
            }
            // D Ű�� ������ �� ���������� �̵�
            else if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y); // ���� �̵�
            }
            else
            {
                // �̵����� ������ �ӵ��� 0���� ����
                rb.velocity = new Vector2(0f, rb.velocity.y);
            }
        }
    }

    // ���� �浹���� �� ȣ��Ǵ� �Լ�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            canMove = false; // ���� �浹���� �� �̵��� ����
            rb.velocity = Vector2.zero; // ���� �̵� �ӵ� 0���� ����

            // ������ �浹�� ������ �о�� (���� �б�)
            Vector2 pushDirection = (transform.position - collision.transform.position).normalized; // ������ ����� ���� ���
            rb.AddForce(pushDirection * forcePush, ForceMode2D.Impulse); // ������ �о��
        }
    }

    // ���� ��� �浹�ϰ� ���� �� ȣ��Ǵ� �Լ�
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // ���� �ε����� �� ĳ���Ͱ� ���� ���� �ʵ��� �о��
            Vector2 pushDirection = (transform.position - collision.transform.position).normalized; // ������ ����� ���� ���
            rb.velocity = new Vector2(0f, rb.velocity.y); // ���� �ӵ� 0���� ����, ���� �ӵ� ����
            rb.AddForce(pushDirection * forcePush, ForceMode2D.Impulse); // ������ �о��
        }
    }

    // ������ ����� �� ȣ��Ǵ� �Լ�
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            canMove = true; // ������ ����� �̵� ���� ���·� ����
        }
    }
}
