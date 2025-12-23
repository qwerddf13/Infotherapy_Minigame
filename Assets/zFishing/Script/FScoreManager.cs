using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FScoreManager : MonoBehaviour
{
    public static FScoreManager instance;
    public int currentScore = 0;
    public TextMeshProUGUI scoreText;

    [Header("효과음 설정")]
    public AudioSource audioSource;
    public AudioClip scoreSound;
    public AudioClip hitSound;

    void Awake() 
    { 
        if (instance == null) instance = this; 
        else Destroy(gameObject); // 중복 인스턴스 방지
    }

    public void PlaySFX(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;
        }
        PlaySFX(scoreSound);
        Debug.Log("현재 점수: " + currentScore);
    }
}