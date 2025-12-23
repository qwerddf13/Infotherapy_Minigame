using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] Rank rankScript;

    [SerializeField] RectTransform resultContainer;
    [SerializeField] EndCard endCard;

    public bool isGameOver = false;

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

    async void ShowGameOver()
    {
        isGameOver = true;

        if (resultContainer != null)
        {
            endCard.EndCardAppear();
            LeanTween.moveY(resultContainer, 0, 2f).setEase(LeanTweenType.easeOutQuint).setDelay(1f);
        }
        
        await rankScript.BeforeWriteLeaderboard(Score.instance.GetFinalScore());
    }
}