using UnityEngine;
using UnityEngine.SceneManagement; // ?�� ?��?��?�� ?��?�� 추�??

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // ?���??�� ?��?��?��?��

    public int leftScore = 0; // ?���? ?��?��?��?�� ?��?��
    public int rightScore = 0; // ?��른쪽 ?��?��?��?�� ?��?��

    public UnityEngine.UI.Text leftScoreText; // ?���? ?��?�� UI
    public UnityEngine.UI.Text rightScoreText; // ?��른쪽 ?��?�� UI

    public int maxScore = 11; // 최�?? ?��?�� (GameOver�? ?��?��)
    public int GetRightScore()
    {
    return rightScore;
    }

    public int GetLeftScore()
    {
        return leftScore;
    }

    void Awake()
    {
        // ?���??�� ?��?��
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return; // 중복?�� ?��브젝?���? ?��괴된 경우 초기?�� 방�??
        }

        // ?��?�� UI 초기?��
        UpdateScoreText();
    }

    // ?���? ?��?�� 추�??
    public void AddLeftScore(int amount)
    {
        leftScore += amount;
        UpdateScoreText();
        CheckGameOver(); // GameOver 조건 ?��?��
    }

    // ?��른쪽 ?��?�� 추�??
    public void AddRightScore(int amount)
    {
        rightScore += amount;
        UpdateScoreText();
        CheckGameOver(); // GameOver 조건 ?��?��
    }

    // ?��?�� UI ?��?��?��?��
    private void UpdateScoreText()
    {
        if (leftScoreText != null)
        {
            leftScoreText.text = leftScore.ToString(); // ?��?���? ?��?��
        }

        if (rightScoreText != null)
        {
            rightScoreText.text = rightScore.ToString(); // ?��?���? ?��?��
        }
    }

    // 게임 종료 조건 ?��?��
    private void CheckGameOver()
    {
        if (leftScore >= maxScore || rightScore >= maxScore)
        {
            // GameOver ?��?���? ?��?��
            SceneManager.LoadScene("GameOver");
        }
    }
    
}
