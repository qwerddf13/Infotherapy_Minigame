using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FScoreManager : MonoBehaviour
{
    public static FScoreManager instance;
    public int currentScore = 0;
    public TextMeshProUGUI scoreText;

    void Awake() 
    { 
        // 싱글톤 패턴: 어디서든 instance로 접근 가능하게 합니다.
        if (instance == null) instance = this; 
    }

    // 물고기가 죽을 때 이 함수를 호출합니다.
    public void AddScore(int amount)
    {
        currentScore += amount;
        Debug.Log("현재 점수: " + currentScore);

        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;
        }
    }
    
    // 절대 Update() 안에서 AddScore()를 호출하지 마세요!
}