using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PenaltyKickScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    
    // ★ 골키퍼 참조 추가
    public GoalKeeper goalKeeper; 

    public int currentScore = 0;

    void Start()
    {
        // 만약 인스펙터에서 할당 안했다면 자동으로 찾기 시도
        if (goalKeeper == null) goalKeeper = FindObjectOfType<GoalKeeper>();

        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;

        // ★ 골을 넣을 때마다 골키퍼 속도 증가 함수 호출
        if (goalKeeper != null)
        {
            goalKeeper.IncreaseSpeed();
        }

        UpdateScoreUI();
    }

    // ... (이하 기존 코드와 동일)
    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "점수: " + currentScore;
    }
}