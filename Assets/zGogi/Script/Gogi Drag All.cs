using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GogiDragAll : MonoBehaviour
{
    // 클래스 이름과 타입 이름을 똑같이 GogiDragAll로 맞춰야 에러가 안 납니다.
    public static GogiDragAll instance;

    private Transform dragging = null;
    private Vector3 offset;

    void Awake()
    {
        // 싱글톤 설정
        if (instance == null) instance = this;
    }

    // Copy 스크립트에서 새 고기를 만들자마자 이 함수를 호출할 겁니다.
    public void StartDragging(Transform target)
    {
        dragging = target;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = dragging.position - (Vector3)mousePos;
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 1. 이미 구워지고 있는 고기를 다시 클릭할 때
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

        // 2. 마우스를 떼면 드래그 중단
        if (Input.GetMouseButtonUp(0))
        {
            dragging = null;
        }

        // 3. 드래그 중일 때 위치 업데이트
        if (dragging != null)
        {
            Vector3 targetPos = (Vector3)mousePos + offset;
            targetPos.z = 0;
            dragging.position = targetPos;
        }
    }
}