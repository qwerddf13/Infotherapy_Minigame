using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    // ... (기존 변수들 동일) ...
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

    [Header("Audio Settings")]
    public AudioSource audioSource;      
    public AudioClip goalSound;          
    public AudioClip gameOverSound;      

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
        
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
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
        // ★ 골 판정을 최우선으로 검사
        if (collision.CompareTag("Goal"))
        {
            ProcessGoal();
            return; // 골 판정이 났으므로 아래의 다른 충돌 검사는 무시
        }

        if (collision.CompareTag("GameOver"))
        {
            // 이미 골 처리가 되어 공이 리셋 중(isShot = false)이라면 무시
            if (isShot) ShowGameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 물리 충돌에서도 동일하게 체크
        if (collision.gameObject.CompareTag("GameOver"))
        {
            if (isShot) ShowGameOver();
        }
    }

    // 골 처리 로직을 별도 함수로 분리
    void ProcessGoal()
    {
        if (!isShot) return; // 이미 처리 중이면 중복 실행 방지

        PlaySound(goalSound);
        if (scoreManager != null) scoreManager.AddScore(1);
        
        if (goalUI != null) 
        {
            goalUI.SetActive(true); 
            Invoke("HideGoalUI", 0.5f); 
        }

        ResetBall(); // 공을 제자리로 돌리고 isShot을 false로 변경
    }

    void ShowGameOver()
    {
        if (!isShot) return;

        PlaySound(gameOverSound);
        isShot = false;
        
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.isKinematic = true;
        }
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
            audioSource.PlayOneShot(clip);
    }

    void HideGoalUI()
    {
        if (goalUI != null) goalUI.SetActive(false);
    }

    public void ResetBall()
    {
        isShot = false; // 판정 중복 방지의 핵심
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
        if (arrowHead != null) arrowHead.SetActive(false);
        
        transform.position = startPos;
        UpdatePowerUI(0);
    }

    void UpdatePowerUI(float power)
    {
        if (powerText != null) powerText.text = "Power: " + power.ToString("F1");
    }
}