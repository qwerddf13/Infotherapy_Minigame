using UnityEngine;

public class GoalKeeper : MonoBehaviour
{
    [Header("Movement Settings")]
    public float startSpeed = 3.0f;
    public float maxSpeed = 15.0f;
    public float acceleration = 0.5f;
    public float range = 10.0f;

    [Header("Target & UI")]
    // 이 변수에 충돌할 오브젝트(예: 공)를 직접 드래그 앤 드롭 하세요.
    public GameObject targetObj; 
    public GameObject gameOverPanel;

    private Vector3 startPos;
    private float currentSpeed;
    private float accumulatedTime;
    private bool isStopped = false;

    void Start()
    {
        startPos = transform.position;
        currentSpeed = startSpeed;
        
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (isStopped) return;

        // 속도 증가 및 이동 로직
        currentSpeed = Mathf.Min(currentSpeed + (acceleration * Time.deltaTime), maxSpeed);
        accumulatedTime += Time.deltaTime * currentSpeed;

        float offset = Mathf.PingPong(accumulatedTime, range) - (range / 2f);
        transform.position = startPos + new Vector3(offset, 0, 0);
    }

    // 물리적 충돌 감지
    private void OnCollisionEnter(Collision collision)
    {
        // 부딪힌 오브젝트가 내가 설정한 targetObj와 같은지 확인
        if (collision.gameObject == targetObj)
        {
            StopGame();
        }
    }

    // 외부에서도 호출할 수 있도록 public으로 선언된 정지 함수
    public void StopGame()
    {
        if (isStopped) return; // 이미 멈췄다면 중복 실행 방지

        isStopped = true;
        Debug.Log("Target과 충돌! 골키퍼 정지.");

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // 전체 게임 흐름을 멈추고 싶다면 사용
        // Time.timeScale = 0f; 
    }
}