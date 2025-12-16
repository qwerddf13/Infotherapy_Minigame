using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopEffectManage : MonoBehaviour
{
    public GameObject chopEffect;
    public GameObject chopEffectNormal;
    public Animator animator_Perfect;
    public Animator animator_Normal;
    public GaugeManage gaugeManage;

    void Start()
    {
        
    }

    void Update()
    {

    }

    void OnEnable()
    {
        GaugeManage.OnIsPerfectChop += ShowEffect;
    }

    void OnDisable()
    {
        GaugeManage.OnIsPerfectChop -= ShowEffect;
    }

    void ShowEffect(bool isPerfect)
    {
        if (isPerfect == true)
        {
            chopEffect.SetActive(true);
            animator_Perfect.SetTrigger("Chop");
        }
    }
}
