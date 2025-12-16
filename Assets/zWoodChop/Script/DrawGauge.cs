using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawGauge : MonoBehaviour
{
    public GaugeManage gaugeManage;
    public Image image; // image 쓸 땐 무조건 UnityEngine.UI 써주기!!!!
    public Material flashMaterial;
    Material originMaterial;

    void Start()
    {
        originMaterial = image.material;
    }

    void Update()
    {
        image.fillAmount = gaugeManage.gaugeRatio;
    }

    void OnEnable()
    {
        GaugeManage.OnIsPerfectChop += FlashGauge;
    }

    void OnDisable()
    {
        GaugeManage.OnIsPerfectChop -= FlashGauge;
    }

    void FlashGauge(bool isPerfect)
    {
        if (isPerfect == true)
            StartCoroutine(DoFlash());
    }

    IEnumerator DoFlash()
    {
        image.material = flashMaterial;
        yield return new WaitForSeconds(0.01f);
        image.material = originMaterial;
    }
}
