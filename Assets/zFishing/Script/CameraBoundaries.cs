using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
    // 배경의 끝 좌표를 인스펙터에서 입력하세요
    public float minX, maxX, minY, maxY;

    void LateUpdate()
    {
        // 카메라의 현재 위치를 가져옵니다
        Vector3 viewPos = transform.position;

        // 좌표가 설정한 범위를 벗어나지 못하게 가둡니다 (Mathf.Clamp)
        viewPos.x = Mathf.Clamp(viewPos.x, minX, maxX);
        viewPos.y = Mathf.Clamp(viewPos.y, minY, maxY);

        // 제한된 좌표를 다시 카메라에 적용합니다
        transform.position = viewPos;
    }
}