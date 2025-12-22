using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public int scoreValue = 10;      // 이 물고기의 점수 (인스펙터에서 수정!)
    private Vector2 moveDirection;
    private float destroyX;
    private bool isDead = false;     
    
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
        if (isDead) return;
        transform.Translate(moveDirection * speed * Time.deltaTime);

        if ((moveDirection == Vector2.left && transform.position.x <= destroyX) ||
            (moveDirection == Vector2.right && transform.position.x >= destroyX))
        {
            Destroy(gameObject);
        }
    }

    // 작살(Spear 태그)과 부딪히면 점수를 주고 죽습니다.
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
        if (anim != null) anim.SetTrigger("Die");

        // 매니저에게 내 점수(scoreValue)만큼 더해달라고 합니다.
        if (FScoreManager.instance != null)
        {
            FScoreManager.instance.AddScore(scoreValue);
        }

        Destroy(gameObject, 0.5f);
    }
}