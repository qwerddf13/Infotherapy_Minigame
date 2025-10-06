using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopEffectManage : MonoBehaviour
{
    public GameObject chopEffect;   
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

    void ShowEffect()
    {
        chopEffect.SetActive(true);
        StartCoroutine(DoHideEffect());
    }

    IEnumerator DoHideEffect()
    {
        yield return new WaitForSeconds(0.01f);
        chopEffect.SetActive(false);
    }

}
