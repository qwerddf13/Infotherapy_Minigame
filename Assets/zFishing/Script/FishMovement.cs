using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector2 moveDirection;
    private float destroyX;

    // 생성될 때 방향과 삭제 지점을 설정하는 함수
    public void Setup(Vector2 direction, float xLimit)
    {
        moveDirection = direction;
        destroyX = xLimit;

        // 진행 방향에 맞춰 물고기의 좌우 반전(Flip) 처리
        if (direction == Vector2.right)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // 방향에 따른 삭제 조건
        if (moveDirection == Vector2.left && transform.position.x <= destroyX)
        {
            Destroy(gameObject);
        }
        else if (moveDirection == Vector2.right && transform.position.x >= destroyX)
        {
            Destroy(gameObject);
        }
    }
}