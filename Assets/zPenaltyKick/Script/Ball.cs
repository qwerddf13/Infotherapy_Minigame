using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Shoot Settings")]
    public float powerMultiplier = 10f;
    public float maxForce = 30f;

    [Header("Managers & UI")]
    public ScoreManager scoreManager;
    public GameObject gameOverPanel;
    public GameObject goalUI; // 여기에 미리 만들어둔 Goal 텍스트 오브젝트를 드래그해서 넣으세요!

    private Rigidbody2D rb;
    private Vector2 startPos;
    private Vector2 dragStartPos;
    private bool isShot = false;
    private Camera cam;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        startPos = transform.position;
        
        // 초기화: 모든 패널 꺼두기
        if (rb != null) rb.isKinematic = true;
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (goalUI != null) goalUI.SetActive(false);
    }

    void Update()
    {
        if (rb == null || (gameOverPanel != null && gameOverPanel.activeSelf)) return;

        if (!isShot && Input.GetMouseButtonDown(0))
        {
            dragStartPos = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (!isShot && Input.GetMouseButtonUp(0))
        {
            Vector2 dragEndPos = cam.ScreenToWorldPoint(Input.mousePosition);
            Shoot(dragStartPos, dragEndPos);
        }
    }

    void Shoot(Vector2 start, Vector2 end)
    {
        Vector2 forceDir = start - end;
        if (forceDir.magnitude < 0.2f) return;

        isShot = true;
        rb.isKinematic = false;
        float appliedForce = Mathf.Min(forceDir.magnitude * powerMultiplier, maxForce);
        rb.AddForce(forceDir.normalized * appliedForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 1. 골대 충돌 시
        if (collision.CompareTag("Goal"))
        {
            if (scoreManager != null) scoreManager.AddScore(1);

            // Goal UI 켜기 (GameOverPanel 켜는 것과 똑같은 방식!)
            if (goalUI != null)
            {
                goalUI.SetActive(true);
                Invoke("HideGoalUI", 0.5f);
            }

            ResetBall();
        }

        // 2. 장애물 충돌 시
        if (collision.CompareTag("GameOver"))
        {
            ShowGameOver();
        }
    }

    void ShowGameOver()
    {
        isShot = false;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
    }

    void HideGoalUI()
    {
        if (goalUI != null) goalUI.SetActive(false);
    }

    public void ResetBall()
    {
        isShot = false;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
        transform.position = startPos;
    }
}