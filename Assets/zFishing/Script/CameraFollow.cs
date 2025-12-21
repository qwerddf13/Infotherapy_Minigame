using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;          // 따라갈 대상 (배)
    public float smoothSpeed = 0.125f; // 카메라 움직임의 부드러운 정도
    public Vector3 offset = new Vector3(0, 0, -10); // 카메라와 배 사이의 거리

    // 카메라가 움직일 수 있는 제한 범위 (배경 크기에 맞게 조절)
    public float minX = -28f;
    public float maxX = 28;

    void LateUpdate()
    {
        if (target == null) return;

        // 대상의 위치에 오프셋을 더한 목표 위치 계산
        Vector3 desiredPosition = new Vector3(target.position.x, 0, 0) + offset;
        
        // 카메라가 배경 밖으로 나가지 않게 고정
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);

        // 부드럽게 이동 (Lerp)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}