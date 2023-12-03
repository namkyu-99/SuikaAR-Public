using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    public TMP_Text highScoreText; // UI에 최고점수를 표시할 Text 컴포넌트
    public TMP_Text currentScoreText; // UI에 현재점수를 표시할 Text 컴포넌트
    static private int highScore;
    static private int currentScore;

    void Start()
    {
        // 게임 시작 시 최고점수 불러오기
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = highScore.ToString();
    }

    void Update()
    {
        currentScoreText.text = currentScore.ToString();
        highScoreText.text = highScore.ToString();
    }

    static public void UpdateScore(string objectTag)
    {
        double scoreToAdd = 0;

        switch (objectTag)
        {
            case "blueberry":
                break;
            case "cherry":
                scoreToAdd = 1;
                break;
            case "strawberry":
                scoreToAdd = 2;
                break;
            case "grape":
                scoreToAdd = 3;
                break;
            case "lemon":
                scoreToAdd = 4;
                break;
            case "passionfruit":
                scoreToAdd = 5;
                break;
            case "clementine":
                scoreToAdd = 6;
                break;
            case "apple":
                scoreToAdd = 7;
                break;
            case "cabbage":
                scoreToAdd = 8;
                break;
            case "coconut":
                scoreToAdd = 9;
                break;
            case "watermelon":
                scoreToAdd = 10;
                break;
            default:
                break;
        }
        scoreToAdd = (scoreToAdd * (scoreToAdd + 1)) / 2;

        // 스코어 계산 및 UI 업데이트
        currentScore += (int)scoreToAdd;
        // currentScoreText.text = "Score: " + currentScore.ToString();

        // 최고점수 갱신
        if (currentScore > highScore)
        {
            highScore = currentScore;
            // highScoreText.text = "High Score: " + highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
        }

    }

    void OnApplicationQuit()
    {
        // 게임 종료 시 최고점수 저장
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    void ResetHighScore()
    {
        highScore = 0;
    }

    public static void ResetCurrentScore()
    {
        currentScore = 0;
    }
}