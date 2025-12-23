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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spear") && !isCaught)
        {
            Catch(collision.transform);
        }
    }

    void Catch(Transform spearTransform)
    {   
        if (isCaught) return; 
        isCaught = true;

        if (anim != null) anim.SetTrigger("Die");
        
        if (hitEffectPrefab != null) 
        {
            GameObject effect = Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 1.0f); 
        }

        transform.SetParent(spearTransform);

        if (FScoreManager.instance != null)
        {
            FScoreManager.instance.PlayHitSound();
        }
    }
}