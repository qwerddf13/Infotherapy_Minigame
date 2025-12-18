using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GogiController: MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 offset;

    void Update()
    {
        // 드래그 중일 때 고기의 위치를 마우스 위치에 맞춤
        if (isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos + offset;
        }
    }

    // 마우스 버튼을 눌렀을 때 (고기를 잡을 때)
    private void OnMouseDown()
    {
        isDragging = true;

        // 현재 마우스 위치와 고기 중심 사이의 거리 차이 계산 (튀는 현상 방지)
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = (Vector2)transform.position - mousePos;
    }

    // 마우스 버튼을 뗐을 때 (고기를 놓을 때)
    private void OnMouseUp()
    {
        isDragging = false;
        CheckOnGrill(); // 불판 위에 놓았는지 확인하는 함수 (아래 추가 설명)
    }

    private void CheckOnGrill()
    {
        // 여기에 나중에 "불판 레이어에 닿았는지" 체크하는 로직을 넣으면 됩니다.
    }
}