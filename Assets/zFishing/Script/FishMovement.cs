using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public GameObject hitEffectPrefab; 
    public float speed = 5.0f;
    public int scoreValue = 10;      
    private Vector2 moveDirection;
    private float destroyX;
    
    // isDead 변수는 현재 Catch 로직에서 필요 없으므로 삭제하거나 
    // isCaught와 통합하여 경고를 제거합니다.
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
        if (isCaught) return; // 잡힌 상태면 이동 중지

        transform.Translate(moveDirection * speed * Time.deltaTime);

        if ((moveDirection == Vector2.left && transform.position.x <= destroyX) ||
            (moveDirection == Vector2.right && transform.position.x >= destroyX))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 작살에 부딪혔을 때만 잡기 실행
        if (collision.CompareTag("Spear") && !isCaught)
        {
            Catch(collision.transform);
        }
    }

    void Catch(Transform spearTransform)
    {   
        isCaught = true; // 이동 로직 멈춤
    
        // 1. 애니메이션 실행
        if (anim != null) anim.SetTrigger("Die");
    
        // 2. 이펙트 생성
        if (hitEffectPrefab != null) 
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);

        // 3. 작살의 자식으로 설정하여 함께 이동
        transform.SetParent(spearTransform);

        // 4. 효과음 재생 (FScoreManager 인스턴스 확인)
        if (FScoreManager.instance != null)
        {
            FScoreManager.instance.PlaySFX(FScoreManager.instance.hitSound);
        }
    }
}