using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PenaltyKickScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    
    // ★ 골키퍼 참조 추가
    public GoalKeeper goalKeeper; 

    private int currentScore = 0;
    private int highScore = 0;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        
        // 만약 인스펙터에서 할당 안했다면 자동으로 찾기 시도
        if (goalKeeper == null) goalKeeper = FindObjectOfType<GoalKeeper>();

        UpdateScoreUI();
        UpdateHighScoreUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;

        // ★ 골을 넣을 때마다 골키퍼 속도 증가 함수 호출
        if (goalKeeper != null)
        {
            goalKeeper.IncreaseSpeed();
        }

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            UpdateHighScoreUI();
        }

        UpdateScoreUI();
    }

    // ... (이하 기존 코드와 동일)
    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "점수: " + currentScore;
    }

    void UpdateHighScoreUI()
    {
        if (highScoreText != null)
            highScoreText.text = "최고 점수: " + highScore;
    }

    [ContextMenu("Reset High Score")]
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore = 0;
        UpdateHighScoreUI();
    }
}