using UnityEngine;
using UnityEngine.SceneManagement;

public class BallBounce : MonoBehaviour
{
    public Transform spawnPoint;
    public float fixedSpeed = 10f; // ���� ���� �ӵ�
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetBallSpeed(fixedSpeed); // ���� ���� �� ���� �ӵ��� ����
    }

    // ���� �ٴڿ� ��Ҵ��� ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WallFloor1"))
        {
            ScoreManager.Instance.AddRightScore(1);
            Debug.Log("WallFloor1: ������ �÷��̾� ���� ����!");
            CheckScoreAndEndGame();
            RespawnBall();
        }
        else if (collision.gameObject.CompareTag("WallFloor2"))
        {
            ScoreManager.Instance.AddLeftScore(1);
            Debug.Log("WallFloor2: ���� �÷��̾� ���� ����!");
            CheckScoreAndEndGame();
            RespawnBall();
        }

        // Wall �Ǵ� Player �±׿� �浹�ϸ� �ӵ��� ������Ŵ
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player"))
        {
            SetBallSpeed(fixedSpeed); // ���� �ӵ��� ����
        }
    }

    // ������ Ȯ���ϰ� ���� ���� ���θ� �Ǵ��ϴ� �Լ�
    private void CheckScoreAndEndGame()
    {
        if (ScoreManager.Instance.GetRightScore() >= 11 || ScoreManager.Instance.GetLeftScore() >= 11)
        {
            Debug.Log("���� ����! ���� ���� ������ �̵��մϴ�.");
            GoToEndGame();
        }
    }

    // ���� �ٽ� �����ϴ� �Լ�
    private void RespawnBall()
    {
        transform.position = spawnPoint.position;
        rb.velocity = Vector2.zero; // �ӵ� �ʱ�ȭ
        rb.angularVelocity = 0f;    // ���ӵ� �ʱ�ȭ
        SetBallSpeed(fixedSpeed);   // ������ �ӵ��� ���� �ٽ� ����
    }

    // ���� �ӵ��� ������ ������ �����ϴ� �Լ�
    private void SetBallSpeed(float speed)
    {
        // ���� ���� �̵� ������ �״�� �����ϰ�, ������ �ӵ��� ����
        Vector2 currentDirection = rb.velocity.normalized; // ���� ������ ����
        rb.velocity = currentDirection * speed; // ���� �ӵ� ����
    }

    // EndGame ������ �̵��ϴ� �Լ�
    public void GoToEndGame()
    {
        SceneManager.LoadScene("EndGame");
    }
}
