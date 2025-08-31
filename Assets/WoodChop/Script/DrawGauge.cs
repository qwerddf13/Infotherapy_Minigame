using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawGauge : MonoBehaviour
{
    public GaugeManage gaugeManage;
    public Image image;

    void Start()
    {
        
    }


    void Update()
    {
        image.fillAmount = gaugeManage.gaugeRatio;
    }
}
