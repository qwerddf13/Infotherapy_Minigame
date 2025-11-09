using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ChopNormalEffect : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Animator animator;
    GameObject chopEffectNormal;
    
    void Start()
    {
        chopEffectNormal = GameObject.Find("ChopEffectNormal");
        spriteRenderer = chopEffectNormal.GetComponent<SpriteRenderer>();
        animator = chopEffectNormal.GetComponent<Animator>();

        if (Random.Range(0, 2) == 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
        animator.SetInteger("Num", Random.Range(0, 3));
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Destroy(chopEffectNormal);
        }
    }
}
