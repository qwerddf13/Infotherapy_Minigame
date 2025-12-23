using UnityEngine;

public class GoalKeeper : MonoBehaviour
{
    [Header("Movement Settings")]
    public float startSpeed = 5.0f;      // 시작 속도
    public float maxSpeed = 20.0f;       // 도달 가능한 최대 속도
    public float speedBoostPerGoal = 1.2f; // 골을 넣을 때마다 증가할 속도량
    public float range = 5.0f;           // 좌우 이동 범위

    [Header("Target & UI")]
    public GameObject targetObj; 
    public GameObject gameOverPanel;

    private Vector3 startPos;
    private float currentSpeed;
    private float accumulatedTime;
    private bool isStopped = false;

    void Start()
    {
        Time.timeScale = 1f;
        startPos = transform.position;
        currentSpeed = startSpeed; // 처음엔 시작 속도로 설정
        
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (isStopped) return;

        // ★ 시간 흐름(Time.deltaTime)에 따른 자동 가속은 제거됨
        // 오직 currentSpeed에 비례하여 위치만 계산합니다.
        accumulatedTime += Time.deltaTime * currentSpeed;

        float offset = Mathf.PingPong(accumulatedTime, range) - (range / 2f);
        transform.position = startPos + new Vector3(offset, 0, 0);
    }

    // 골을 넣었을 때 PenaltyKickScoreManager에서 호출됨
    public void IncreaseSpeed()
    {
        // 현재 속도에 일정 수치를 더함 (최대 속도를 넘지 않음)
        currentSpeed = Mathf.Min(currentSpeed + speedBoostPerGoal, maxSpeed);
        Debug.Log($"골! 현재 속도: {currentSpeed:F1}");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == targetObj)
        {
            StopGame();
        }
    }

    public void StopGame()
    {
        if (isStopped) return;
        isStopped = true;
        Time.timeScale = 0f; 

        if (gameOverPanel != null) gameOverPanel.SetActive(true);
    }
}