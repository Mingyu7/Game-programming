using UnityEngine;
using UnityEngine.SceneManagement;

public class BallBounce : MonoBehaviour
{
    public Transform spawnPoint;
    public float fixedSpeed = 10f; // 공의 고정 속도
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetBallSpeed(fixedSpeed); // 게임 시작 시 공의 속도를 고정
    }

    // 공이 바닥에 닿았는지 감지
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WallFloor1"))
        {
            ScoreManager.Instance.AddRightScore(1);
            Debug.Log("WallFloor1: 오른쪽 플레이어 점수 증가!");
            CheckScoreAndEndGame();
            RespawnBall();
        }
        else if (collision.gameObject.CompareTag("WallFloor2"))
        {
            ScoreManager.Instance.AddLeftScore(1);
            Debug.Log("WallFloor2: 왼쪽 플레이어 점수 증가!");
            CheckScoreAndEndGame();
            RespawnBall();
        }

        // Wall 또는 Player 태그와 충돌하면 속도를 고정시킴
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player"))
        {
            SetBallSpeed(fixedSpeed); // 고정 속도로 설정
        }
    }

    // 점수를 확인하고 게임 종료 여부를 판단하는 함수
    private void CheckScoreAndEndGame()
    {
        if (ScoreManager.Instance.GetRightScore() >= 11 || ScoreManager.Instance.GetLeftScore() >= 11)
        {
            Debug.Log("게임 종료! 엔드 게임 씬으로 이동합니다.");
            GoToEndGame();
        }
    }

    // 공을 다시 생성하는 함수
    private void RespawnBall()
    {
        transform.position = spawnPoint.position;
        rb.velocity = Vector2.zero; // 속도 초기화
        rb.angularVelocity = 0f;    // 각속도 초기화
        SetBallSpeed(fixedSpeed);   // 고정된 속도로 공을 다시 시작
    }

    // 공의 속도를 고정된 값으로 설정하는 함수
    private void SetBallSpeed(float speed)
    {
        // 공의 현재 이동 방향을 그대로 유지하고, 고정된 속도로 설정
        Vector2 currentDirection = rb.velocity.normalized; // 현재 방향을 유지
        rb.velocity = currentDirection * speed; // 고정 속도 설정
    }

    // EndGame 씬으로 이동하는 함수
    public void GoToEndGame()
    {
        SceneManager.LoadScene("EndGame");
    }
}
