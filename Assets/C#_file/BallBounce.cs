using UnityEngine;
using UnityEngine.SceneManagement;

public class BallBounce : MonoBehaviour
{
    // ���� ����Ʈ�� ������ ����
    public Transform spawnPoint;

    // ���� �ٴڿ� ��Ҵ��� ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // WallFloor1 �Ǵ� WallFloor2 �±׿� ����
        if (collision.gameObject.CompareTag("WallFloor1"))
        {
            ScoreManager.Instance.AddRightScore(1);
            Debug.Log("WallFloor1: ������ �÷��̾� ���� ����!");
            CheckScoreAndEndGame(); // ������ Ȯ���ϰ� ���� ���� ���� üũ
            RespawnBall();
        }
        else if (collision.gameObject.CompareTag("WallFloor2"))
        {
            ScoreManager.Instance.AddLeftScore(1);
            Debug.Log("WallFloor2: ���� �÷��̾� ���� ����!");
            CheckScoreAndEndGame(); // ������ Ȯ���ϰ� ���� ���� ���� üũ
            RespawnBall();
        }
    }

    // ������ Ȯ���ϰ� ���� ���� ���θ� �Ǵ��ϴ� �Լ�
    private void CheckScoreAndEndGame()
    {
        // ������ �÷��̾� �Ǵ� ���� �÷��̾��� ������ 11 �̻��̸� ���� ����
        if (ScoreManager.Instance.GetRightScore() >= 11 || ScoreManager.Instance.GetLeftScore() >= 11)
        {
            Debug.Log("���� ����! ���� ���� ������ �̵��մϴ�.");
            GoToEndGame();
        }
    }

    // ���� �ٽ� �����ϴ� �Լ�
    private void RespawnBall()
    {
        // ���� ��ġ�� ���� ����Ʈ�� �̵�
        transform.position = spawnPoint.position;

        // ���� �ӵ��� �ʱ�ȭ
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }

    // EndGame ������ �̵��ϴ� �Լ�
    public void GoToEndGame()
    {
        SceneManager.LoadScene("EndGame");
    }
}
