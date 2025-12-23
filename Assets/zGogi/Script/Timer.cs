using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI finalScoreText;

    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 0)
            {
                remainingTime = 0;
                ShowGameOver();
            }
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        if (timerText != null)
        {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    void ShowGameOver()
    {
        isGameOver = true;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);

    
            if (Score.instance != null && finalScoreText != null)
            {
                int score = Score.instance.GetFinalScore();
                finalScoreText.text = "Final Score: " + score.ToString() + " score";
            }
        }


        AudioSource bgm = Camera.main.GetComponent<AudioSource>();
        if (bgm != null)
        {
            bgm.Stop();
        }

        Time.timeScale = 0f;
    }
}