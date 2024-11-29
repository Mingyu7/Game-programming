using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // GameScene으로 전환하는 함수
    public void GoToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
