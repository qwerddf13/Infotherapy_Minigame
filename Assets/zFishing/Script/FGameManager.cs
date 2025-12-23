using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class FGameManager : MonoBehaviour
{
    public static FGameManager instance;

    public RectTransform resultContainer;    // 결과 창 Panel 오브젝트
    public TextMeshProUGUI finalScoreText; // 결과 창에 표시할 최종 점수 텍스트
    public EndCard endCard;
    public Rank rankScript1;
    public Rank rankScript2;
    public Rank rankScript3;
    public static bool isGameOver = false;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        Time.timeScale = 10f;
    }

    // 게임 종료 함수
    public async void EndGame()
    {
        if (isGameOver) return;
        isGameOver = true;

        Debug.Log("게임 종료! 특정 지점 도달.");



        // 1. 결과 창 활성화
        if (resultContainer != null) 
        {
            endCard.EndCardAppear();
            LeanTween.moveY(resultContainer, 0, 2f).setEase(LeanTweenType.easeOutQuint).setDelay(3f);
        }

        try
        {
            await rankScript1.BeforeWriteLeaderboard(FScoreManager.instance.currentScore);
            await rankScript1.BeforeWriteLeaderboard(FScoreManager.instance.currentScore);
            await rankScript1.BeforeWriteLeaderboard(FScoreManager.instance.currentScore);
        }
        catch(Exception ex)
        {
            Debug.Log("리더보드 실패: " + ex.Message);
        }
    }

    // 다시 시작 버튼 등에 연결할 함수
    public void RestartGame()
    {
        Time.timeScale = 1; // 시간 다시 흐르게 설정
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}