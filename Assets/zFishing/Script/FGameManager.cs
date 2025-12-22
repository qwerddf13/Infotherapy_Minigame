using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FGameManager : MonoBehaviour
{
    public static FGameManager instance;

    public GameObject resultPanel;    // 결과 창 Panel 오브젝트
    public TextMeshProUGUI finalScoreText; // 결과 창에 표시할 최종 점수 텍스트
    private bool isGameOver = false;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        // 시작할 때 결과 창은 꺼둡니다.
        if (resultPanel != null) resultPanel.SetActive(false);
    }

    // 게임 종료 함수
    public void EndGame()
    {
        if (isGameOver) return;
        isGameOver = true;

        Debug.Log("게임 종료! 특정 지점 도달.");

        // 1. 결과 창 활성화
        if (resultPanel != null) resultPanel.SetActive(true);

        // 2. 최종 점수 표시
        if (finalScoreText != null && FScoreManager.instance != null)
        {
            finalScoreText.text = "Final Score: " + FScoreManager.instance.currentScore.ToString();
        }

        // 3. 게임 시간 정지 (보트 이동, 물고기 생성 등 중지)
        Time.timeScale = 0;
    }

    // 다시 시작 버튼 등에 연결할 함수
    public void RestartGame()
    {
        Time.timeScale = 1; // 시간 다시 흐르게 설정
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}