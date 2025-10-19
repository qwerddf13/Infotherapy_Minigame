using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopEffect : MonoBehaviour
{
    // 오류 있음: 퍼펙트때만 이펙트 나옴. 아마 꽉찬 게이지 감지 관련 문제로 추정.
    public Animator animator;
    public GaugeManage gaugeManage;
    public SpriteRenderer spriteRenderer;
    void Start()
    {

    }


    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            spriteRenderer.enabled = false;
        }
    }

    void OnEnable()
    {
        Player.OnCutWood += ShowEffect;
    }

    void OnDisable()
    {
        Player.OnCutWood -= ShowEffect;
    }

    void ShowEffect(bool _)
    {
        spriteRenderer.enabled = true;
        if (gaugeManage.isPerfectLast == true)
        {
            animator.SetBool("isPerfect", true);
        }
        else
        {
            animator.SetBool("isPerfect", false);
        }
        animator.SetTrigger("Chop");
    }
}
