using UnityEngine;
using UnityEngine.SceneManagement; // 씬 전환을 위해 추가

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // 싱글톤 인스턴스

    public int leftScore = 0; // 왼쪽 플레이어 점수
    public int rightScore = 0; // 오른쪽 플레이어 점수

    public UnityEngine.UI.Text leftScoreText; // 왼쪽 점수 UI
    public UnityEngine.UI.Text rightScoreText; // 오른쪽 점수 UI

    public int maxScore = 11; // 최대 점수 (GameOver로 전환)

    void Awake()
    {
        // 싱글톤 설정
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return; // 중복된 오브젝트가 파괴된 경우 초기화 방지
        }

        // 점수 UI 초기화
        UpdateScoreText();
    }

    // 왼쪽 점수 추가
    public void AddLeftScore(int amount)
    {
        leftScore += amount;
        UpdateScoreText();
        CheckGameOver(); // GameOver 조건 확인
    }

    // 오른쪽 점수 추가
    public void AddRightScore(int amount)
    {
        rightScore += amount;
        UpdateScoreText();
        CheckGameOver(); // GameOver 조건 확인
    }

    // 점수 UI 업데이트
    private void UpdateScoreText()
    {
        if (leftScoreText != null)
        {
            leftScoreText.text = leftScore.ToString(); // 점수만 표시
        }

        if (rightScoreText != null)
        {
            rightScoreText.text = rightScore.ToString(); // 점수만 표시
        }
    }

    // 게임 종료 조건 확인
    private void CheckGameOver()
    {
        if (leftScore >= maxScore || rightScore >= maxScore)
        {
            // GameOver 씬으로 이동
            SceneManager.LoadScene("GameOver");
        }
    }
}
