using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copy : MonoBehaviour
{
    void Update()
    {
        if (Time.timeScale == 0) return;


        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit && hit.transform.CompareTag("Origin"))
            {
                GameObject newGogi = Instantiate(hit.transform.gameObject, hit.transform.position, hit.transform.rotation);
                newGogi.name = "Clone_Gogi";
                newGogi.tag = "Gogi";

                Gogi g = newGogi.GetComponent<Gogi>();
                if (g != null)
                {
                    g.ResetGogi();
                    g.Flip();
                }

                // 에러 해결: 타입을 GogiDragAll로 맞춰서 호출
                if (GogiDragAll.instance != null)
                {
                    GogiDragAll.instance.StartDragging(newGogi.transform);
                }
            }
        }
    }
}