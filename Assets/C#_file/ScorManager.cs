using UnityEngine;
using UnityEngine.SceneManagement; // ?î¨ ?†Ñ?ôò?ùÑ ?úÑ?ï¥ Ï∂îÍ??

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // ?ã±Í∏??Ü§ ?ù∏?ä§?Ñ¥?ä§

    public int leftScore = 0; // ?ôºÏ™? ?îå?†à?ù¥?ñ¥ ?†ê?àò
    public int rightScore = 0; // ?ò§Î•∏Ï™Ω ?îå?†à?ù¥?ñ¥ ?†ê?àò

    public UnityEngine.UI.Text leftScoreText; // ?ôºÏ™? ?†ê?àò UI
    public UnityEngine.UI.Text rightScoreText; // ?ò§Î•∏Ï™Ω ?†ê?àò UI

    public int maxScore = 11; // ÏµúÎ?? ?†ê?àò (GameOverÎ°? ?†Ñ?ôò)
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
        // ?ã±Í∏??Ü§ ?Ñ§?†ï
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return; // Ï§ëÎ≥µ?êú ?ò§Î∏åÏ†ù?ä∏Í∞? ?ååÍ¥¥Îêú Í≤ΩÏö∞ Ï¥àÍ∏∞?ôî Î∞©Ï??
        }

        // ?†ê?àò UI Ï¥àÍ∏∞?ôî
        UpdateScoreText();
    }

    // ?ôºÏ™? ?†ê?àò Ï∂îÍ??
    public void AddLeftScore(int amount)
    {
        leftScore += amount;
        UpdateScoreText();
        CheckGameOver(); // GameOver Ï°∞Í±¥ ?ôï?ù∏
    }

    // ?ò§Î•∏Ï™Ω ?†ê?àò Ï∂îÍ??
    public void AddRightScore(int amount)
    {
        rightScore += amount;
        UpdateScoreText();
        CheckGameOver(); // GameOver Ï°∞Í±¥ ?ôï?ù∏
    }

    // ?†ê?àò UI ?óÖ?ç∞?ù¥?ä∏
    private void UpdateScoreText()
    {
        if (leftScoreText != null)
        {
            leftScoreText.text = leftScore.ToString(); // ?†ê?àòÎß? ?ëú?ãú
        }

        if (rightScoreText != null)
        {
            rightScoreText.text = rightScore.ToString(); // ?†ê?àòÎß? ?ëú?ãú
        }
    }

    // Í≤åÏûÑ Ï¢ÖÎ£å Ï°∞Í±¥ ?ôï?ù∏
    private void CheckGameOver()
    {
        if (leftScore >= maxScore || rightScore >= maxScore)
        {
            // GameOver ?î¨?úºÎ°? ?ù¥?èô
            SceneManager.LoadScene("GameOver");
        }
    }
    
}
