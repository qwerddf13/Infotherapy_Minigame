using UnityEngine;

public class GoalKeeper : MonoBehaviour
{
    [Header("Movement Settings")]
    public float startSpeed = 3.0f;
    public float maxSpeed = 15.0f;
    public float acceleration = 0.5f;
    public float range = 5.0f;

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
        currentSpeed = startSpeed;
        
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (isStopped) return;

        currentSpeed = Mathf.Min(currentSpeed + (acceleration * Time.deltaTime), maxSpeed);
        accumulatedTime += Time.deltaTime * currentSpeed;

        float offset = Mathf.PingPong(accumulatedTime, range) - (range / 2f);
        transform.position = startPos + new Vector3(offset, 0, 0);
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