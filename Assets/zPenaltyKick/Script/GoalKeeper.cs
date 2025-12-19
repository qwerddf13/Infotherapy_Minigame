using UnityEngine;

public class GoalKeeper : MonoBehaviour
{
    [Header("Movement Settings")]
    public float startSpeed = 3.0f;
    public float maxSpeed = 15.0f;
    public float acceleration = 0.5f;
    public float range = 10.0f;

    [Header("Target & UI")]
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

        currentSpeed = Mathf.Min(currentSpeed + (acceleration * Time.deltaTime), maxSpeed);
        accumulatedTime += Time.deltaTime * currentSpeed;

        float offset = Mathf.PingPong(accumulatedTime, range) - (range / 2f);
        transform.position = startPos + new Vector3(offset, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
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
        Debug.Log("Target과 충돌! 골키퍼 정지.");

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
}   