using UnityEngine;
using UnityEngine.SceneManagement;

public class BallBounce : MonoBehaviour
{
    // 스폰 포인트를 설정할 변수
    public Transform spawnPoint;

    // 공이 바닥에 닿았는지 감지
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // WallFloor1 또는 WallFloor2 태그에 반응
        if (collision.gameObject.CompareTag("WallFloor1"))
        {
            ScoreManager.Instance.AddRightScore(1);
            Debug.Log("WallFloor1: 오른쪽 플레이어 점수 증가!");
            CheckScoreAndEndGame(); // 점수를 확인하고 게임 종료 여부 체크
            RespawnBall();
        }
        else if (collision.gameObject.CompareTag("WallFloor2"))
        {
            ScoreManager.Instance.AddLeftScore(1);
            Debug.Log("WallFloor2: 왼쪽 플레이어 점수 증가!");
            CheckScoreAndEndGame(); // 점수를 확인하고 게임 종료 여부 체크
            RespawnBall();
        }
    }

    // 점수를 확인하고 게임 종료 여부를 판단하는 함수
    private void CheckScoreAndEndGame()
    {
        // 오른쪽 플레이어 또는 왼쪽 플레이어의 점수가 11 이상이면 게임 종료
        if (ScoreManager.Instance.GetRightScore() >= 11 || ScoreManager.Instance.GetLeftScore() >= 11)
        {
            Debug.Log("게임 종료! 엔드 게임 씬으로 이동합니다.");
            GoToEndGame();
        }
    }

    // 공을 다시 생성하는 함수
    private void RespawnBall()
    {
        // 공의 위치를 스폰 포인트로 이동
        transform.position = spawnPoint.position;

        // 공의 속도를 초기화
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }

    // EndGame 씬으로 이동하는 함수
    public void GoToEndGame()
    {
        SceneManager.LoadScene("EndGame");
    }
}
