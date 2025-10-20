using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopEffect : MonoBehaviour
{
    public Animator animator;
    public GaugeManage gaugeManage;

    void Start()
    {

    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            gameObject.SetActive(false);
        }
    }
}
