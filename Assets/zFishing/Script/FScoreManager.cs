using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FScoreManager : MonoBehaviour
{
    public static FScoreManager instance;
    public int currentScore = 0;
    public TextMeshProUGUI scoreText;

    [Header("효과음 설정 (AudioSource 방식)")]
    public AudioSource scoreAudioSource; 
    public AudioSource hitAudioSource;
    public AudioSource shootAudioSource;

    [Header("배경 음악 설정")]
    public AudioSource backgroundAudioSource; // 배경 음악용 추가

    void Awake() 
    { 
        if (instance == null) instance = this; 
        else Destroy(gameObject); 
    }

    void Start()
    {
        // 게임 시작 시 배경 음악 재생
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundAudioSource != null && !backgroundAudioSource.isPlaying)
        {
            backgroundAudioSource.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        if (backgroundAudioSource != null)
        {
            backgroundAudioSource.Stop();
        }
    }

    public void PlayShootSound()
    {
        if (shootAudioSource != null) shootAudioSource.Play();
    }

    public void PlayHitSound()
    {
        if (hitAudioSource != null) hitAudioSource.Play();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;
        }

        if (scoreAudioSource != null)
        {
            scoreAudioSource.Play();
        }
        
        Debug.Log("현재 점수: " + currentScore);
    }
}