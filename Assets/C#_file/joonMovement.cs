using UnityEngine;

public class joonMovement : MonoBehaviour
{
    public float speed = 5f; // �̵� �ӵ�
    private bool canMove = true; // �̵� ���� ����
    private Rigidbody2D rb; // Rigidbody2D ������Ʈ
    public float forcePush = 5f; // ���� �浹 �� �о�� ��

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canMove)
        {
            // ���� ȭ��ǥ Ű�� ������ �� �������� �̵�
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                MoveCharacter(Vector2.left);
            }
            // ������ ȭ��ǥ Ű�� ������ �� �������� �̵�
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                MoveCharacter(Vector2.right);
            }
            else
            {
                // ����Ű�� ������ ������ �̵� ����
                StopCharacter();
            }
        }
    }

    // ĳ���͸� ���������� �̵���Ű�� �Լ�
    private void MoveCharacter(Vector2 direction)
    {
        // ���� �ӵ��� 0���� �����Ͽ� ���� �ö󰡴� ������ ����
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }

    // ĳ���͸� ���ߴ� �Լ�
    private void StopCharacter()
    {
        // ���� �ӵ��� 0���� �����Ͽ� ���߰� ��
        rb.velocity = new Vector2(0f, rb.velocity.y);
    }

    // ���� �浹���� �� ȣ��Ǵ� �Լ�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            canMove = false; // ���� �浹���� �� �̵��� ����
            rb.velocity = Vector2.zero; // �̵��� ����

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
            // ���� �ε����� �� �ݴ� �������� ��� �б�
            // ���� ��ġ�� ���� �����ϱ� ���� ������ �о��
            Vector2 pushDirection = (transform.position - collision.transform.position).normalized; // ������ ����� ���� ���
            rb.velocity = new Vector2(0f, rb.velocity.y); // ���� �ӵ� 0, ���� �ӵ� ����
            rb.AddForce(pushDirection * forcePush, ForceMode2D.Impulse); // ������ �о��
        }
    }

    // ������ ����� �� ȣ��Ǵ� �Լ�
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            canMove = true; // ������ ����� �� �̵� ���� ���·� ����
        }
    }
}
