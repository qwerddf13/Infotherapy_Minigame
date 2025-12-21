using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public float moveSpeed = 1.5f;     // 배가 자동으로 움직이는 속도 (천천히)
    public float startX = 28f;     // 다시 나타날 왼쪽 시작 지점
    public float endX = -28f;        // 사라질 오른쪽 끝 지점

    void Update()
    {
        // 1. 매 프레임마다 오른쪽(Vector3.right)으로 이동
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
}