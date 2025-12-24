using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI finalScoreText;
    public RectTransform resultContainer;    // 결과 창 Panel 오브젝트
    public EndCard endCard;
    public Rank rankScript;

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

    public async void ShowGameOver()
    {
        isGameOver = true;

        if (gameOverPanel != null)
        {
            endCard.EndCardAppear();
            LeanTween.moveY(resultContainer, 0, 2f).setEase(LeanTweenType.easeOutQuint).setDelay(3f);

            try
            {
                await rankScript.BeforeWriteLeaderboard(FScoreManager.instance.currentScore);
            }
            catch(Exception ex)
            {
                Debug.Log("리더보드 실패: " + ex.Message);
            }

    
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
    }
}