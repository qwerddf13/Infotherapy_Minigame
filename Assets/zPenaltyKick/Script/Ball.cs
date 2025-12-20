using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Shoot Settings")]
    public float powerMultiplier = 10f; 
    public float maxForce = 30f;       

    [Header("Reset Settings")]
    public float resetDelay = 2f;
    public float screenLimitY = 6f;
    public float screenLimitX = 10f;

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
        
        if (rb != null) rb.isKinematic = true;
    }

    void Update()
    {
        if (rb == null) return;

        if (!isShot && Input.GetMouseButtonDown(0))
        {
            dragStartPos = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (!isShot && Input.GetMouseButtonUp(0))
        {
            Vector2 dragEndPos = cam.ScreenToWorldPoint(Input.mousePosition);
            Shoot(dragStartPos, dragEndPos);
        }

        if (isShot)
        {
            if (Mathf.Abs(transform.position.x) > screenLimitX || 
                Mathf.Abs(transform.position.y) > screenLimitY)
            {
                ResetBall();
            }
            
            if (rb.velocity.magnitude < 0.1f)
            {
                Invoke("ResetBall", resetDelay);
            }
        }
    }

    void Shoot(Vector2 start, Vector2 end)
    {
        Vector2 forceDir = start - end;
        float dragDistance = forceDir.magnitude;

        if (dragDistance < 0.2f) return;

        isShot = true;
        rb.isKinematic = false;

        float appliedForce = Mathf.Min(dragDistance * powerMultiplier, maxForce);
        rb.AddForce(forceDir.normalized * appliedForce, ForceMode2D.Impulse);
    }

    public void ResetBall()
    {
        CancelInvoke("ResetBall");

        isShot = false;
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
        transform.position = startPos;
    }
}