using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public GameObject hitEffectPrefab; // 여기에 이펙트 프리팹을 넣을 거예요.
    public float speed = 5.0f;
    public int scoreValue = 10;      // 이 물고기의 점수 (인스펙터에서 수정!)
    private Vector2 moveDirection;
    private float destroyX;
    private bool isDead = false;     
    private bool isCaught = false;
    
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
        if (isCaught) return;
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
        if (collision.CompareTag("Spear") && !isCaught)
        {
            Catch(collision.transform);
        }
    }


    void Die()
    {
        isDead = true;

        // 1. 이펙트 생성 (물고기 위치에 생성)
        if (hitEffectPrefab != null)
        {
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
        }

        // 2. 점수 추가 및 애니메이션 (기존 코드)
        if (FScoreManager.instance != null) FScoreManager.instance.AddScore(scoreValue);
        if (anim != null) anim.SetTrigger("Die");

        Destroy(gameObject, 0.5f);
    }
    void Catch(Transform spearTransform)
    {   
        isCaught = true;
    
        // 1. 죽는 애니메이션이나 이펙트 실행
        if (anim != null) anim.SetTrigger("Die");
    
        // 2. 이펙트 생성 (선택 사항)
        if (hitEffectPrefab != null) Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);

        transform.SetParent(spearTransform);
        if (FScoreManager.instance != null)
        {
            FScoreManager.instance.PlaySFX(FScoreManager.instance.hitSound);
        }
    }
    
}