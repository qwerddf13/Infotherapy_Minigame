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
        GaugeManage.OnPerfectChop += ShowEffect;
    }

    void OnDisable()
    {
        GaugeManage.OnPerfectChop -= ShowEffect;
    }
    
    void ShowEffect()
    {
        chopEffect.SetActive(true);
        animator.SetTrigger("Chop");
    }
}
