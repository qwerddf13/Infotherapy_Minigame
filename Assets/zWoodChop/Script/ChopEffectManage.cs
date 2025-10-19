using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopEffectManage : MonoBehaviour
{
    public GameObject chopEffect;
    public Animator animator;
    public GaugeManage gaugeManage;
    void Start()
    {

    }


    void Update()
    {

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
        chopEffect.SetActive(true);
        if (gaugeManage.isPerfectLast == true)
        {
            animator.SetBool("isPerfect", true);
        }
        else
        {
            animator.SetBool("isPerfect", false);
        }
        animator.SetTrigger("Chop");
        StartCoroutine(DoHideEffect());
    }
    IEnumerator DoHideEffect()
    {
        yield return new WaitForSeconds(0.12f);
        chopEffect.SetActive(false);
    }
}
