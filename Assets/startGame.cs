using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // �� ��ȯ�� ���� �ʿ�

public class startGame : MonoBehaviour
{
    // ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void OnGameStartButtonClicked()
    {
        // "GameScene"���� ���� ��ȯ
        SceneManager.LoadScene("GameScene");
    }
}
