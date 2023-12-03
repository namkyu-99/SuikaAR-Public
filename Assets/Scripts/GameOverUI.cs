using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void Restart()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        Score.ResetCurrentScore();
        // 현재 씬을 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
