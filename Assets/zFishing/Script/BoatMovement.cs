using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public float startX = 28f;
    public float finishX = -28f; // 게임이 종료될 목표 X 좌표
    private bool canMove = true;

    void Update()
    {
        if (!canMove) return;

        // 1. 오른쪽으로 계속 이동
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // 2. 특정 좌표(finishX)에 도달했는지 체크
        if (transform.position.x <= finishX)
        {
            canMove = false; // 이동 중지
            FGameManager.instance.EndGame(); // 게임 종료 호출
        }
    }
}