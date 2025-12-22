using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    [Header("Shoot Settings")]
    public float powerMultiplier = 10f;
    public float maxForce = 30f;

    [Header("Managers & UI")]
    public PenaltyKickScoreManager scoreManager; 
    public GameObject gameOverPanel;             
    public GameObject goalUI;           
    public TextMeshProUGUI powerText;            

    [Header("Arrow UI")]
    public GameObject arrowHead;                 

    private Rigidbody2D rb;
    private LineRenderer lr;
    private Vector2 startPos;
    private Vector2 dragStartPos;
    private bool isShot = false;
    private Camera cam;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        cam = Camera.main;
        startPos = transform.position;
        
        if (rb != null) 
        {
            rb.isKinematic = true;
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous; 
        }

        if (lr != null) lr.enabled = false;
        if (arrowHead != null) arrowHead.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (goalUI != null) goalUI.SetActive(false);
        
        UpdatePowerUI(0);
    }

    void Update()
    {
        if (rb == null || (gameOverPanel != null && gameOverPanel.activeSelf)) return;

        if (!isShot && Input.GetMouseButtonDown(0))
        {
            dragStartPos = cam.ScreenToWorldPoint(Input.mousePosition);
            if (lr != null) lr.enabled = true;
            if (arrowHead != null) arrowHead.SetActive(true);
        }

        if (!isShot && Input.GetMouseButton(0))
        {
            Vector2 currentMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 forceDir = dragStartPos - currentMousePos;
            float currentForce = Mathf.Min(forceDir.magnitude * powerMultiplier, maxForce);
            
            UpdatePowerUI(currentForce);
            DrawGuideLine(forceDir);
        }

        if (!isShot && Input.GetMouseButtonUp(0))
        {
            if (lr != null) lr.enabled = false;
            if (arrowHead != null) arrowHead.SetActive(false);
            Shoot(dragStartPos, cam.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    void DrawGuideLine(Vector2 direction)
    {
        if (lr == null) return;
        lr.positionCount = 2;
        lr.SetPosition(0, transform.position);
        Vector3 endPoint = (Vector2)transform.position + direction; 
        lr.SetPosition(1, endPoint);

        if (arrowHead != null)
        {
            arrowHead.transform.position = endPoint;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            arrowHead.transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
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
        if (collision.CompareTag("Goal"))
        {
            if (scoreManager != null) scoreManager.AddScore(1);
            
            // 1. Goal 텍스트는 켜고 1.2초 뒤에 꺼지도록 예약 (따로 작동)
            if (goalUI != null) 
            {
                goalUI.SetActive(true); 
                Invoke("HideGoalUI", 0.5f); 
            }

            // 2. [핵심] 공은 텍스트와 상관없이 즉시 원위치
            ResetBall(); 
        }

        if (collision.CompareTag("GameOver"))
        {
            ShowGameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GameOver"))
        {
            ShowGameOver();
        }
    }

    void ShowGameOver()
    {
        isShot = false;
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.isKinematic = true;
        }
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
    }

    void HideGoalUI()
    {
        if (goalUI != null) goalUI.SetActive(false);
    }

    public void ResetBall()
    {
        isShot = false;
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
        if (arrowHead != null) arrowHead.SetActive(false);
        
        transform.position = startPos;
        UpdatePowerUI(0);
        // 여기서 goalUI.SetActive(false)를 지웠으므로 텍스트는 유지됩니다.
    }

    void UpdatePowerUI(float power)
    {
        if (powerText != null) powerText.text = "Power: " + power.ToString("F1");
    }
}