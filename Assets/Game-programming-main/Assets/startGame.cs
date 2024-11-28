using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // 씬 전환을 위해 필요

public class startGame : MonoBehaviour
{
    // 버튼 클릭 시 호출되는 함수
    public void OnGameStartButtonClicked()
    {
        // "GameScene"으로 씬을 전환
        SceneManager.LoadScene("GameScene");
    }
}
