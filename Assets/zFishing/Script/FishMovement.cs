using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public int scoreValue = 10;      // 이 물고기를 잡았을 때 얻는 점수
    private Vector2 moveDirection;
    private float destroyX;
    private bool isDead = false;     // 죽었는지 확인 (중복 충돌 방지)
    
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Setup(Vector2 direction, float xLimit)
    {
        moveDirection = direction;
        destroyX = xLimit;

        if (direction == Vector2.right)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    void Update()
    {
        if (isDead) return; // 죽었다면 이동 중지

        transform.Translate(moveDirection * speed * Time.deltaTime);

        if ((moveDirection == Vector2.left && transform.position.x <= destroyX) ||
            (moveDirection == Vector2.right && transform.position.x >= destroyX))
        {
            Destroy(gameObject);
        }
    }

    // 작살과 부딪혔을 때 호출되는 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spear") && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        
        // 1. 죽는 애니메이션 실행 (파라미터 이름이 "Die"라고 가정)
        if (anim != null) anim.SetTrigger("Die");

        // 2. 점수 추가 (나중에 ScoreManager를 만들면 거기서 호출)
        Debug.Log(scoreValue);

        // 3. 이펙트와 함께 사라지기 (0.5초 뒤 삭제, 애니메이션 시간에 맞춰 조절)
        Destroy(gameObject, 0.5f);
    }
}