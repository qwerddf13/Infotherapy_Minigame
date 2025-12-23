using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GogiDragAll : MonoBehaviour
{
    public static GogiDragAll instance;

    private Transform dragging = null;
    private Vector3 offset;
    [SerializeField] Timer timerScript;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void StartDragging(Transform target)
    {
        if (timerScript.isGameOver == false)
        {
            dragging = target;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = dragging.position - (Vector3)mousePos;
        }
    }

    void Update()
    {
        if (timerScript.isGameOver == false)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
                if (hit && hit.transform.CompareTag("Gogi"))
                {
                    StartDragging(hit.transform);

                    Gogi gogi = hit.transform.GetComponent<Gogi>();
                    if (gogi != null) gogi.Flip();
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                dragging = null;
            }

    
            if (dragging != null)
            {
                Vector3 targetPos = (Vector3)mousePos + offset;
                targetPos.z = 0;
                dragging.position = targetPos;
            }
        }
    }
}