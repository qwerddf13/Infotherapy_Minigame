using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeManage : MonoBehaviour
{
    public ScoreManage scoreManage;

    public float maxGauge = 1000;
    public float currGauge = 1000;
    float gaugeDecay = 0.1f;
    float gaugeRegain = 20;
    public float gaugeRatio = 0f;
    void Start()
    {
        StartCoroutine(DoGaugeDecay());
        StartCoroutine(IncreaseDecay());
    }

    void Update()
    {

    }

    public static event Action OnOver_Gauge;

    void OnEnable()
    {
        Player.OnCutWood += RegainGauge;
        GameManage.OnGameOver += () => StopCoroutine(DoGaugeDecay());
    }

    void OnDisable()
    {
        Player.OnCutWood -= RegainGauge;
        GameManage.OnGameOver -= () => StopCoroutine(DoGaugeDecay());
    }

    IEnumerator DoGaugeDecay()
    {
        while (currGauge > 0)
        {
            currGauge -= gaugeDecay;

            if (currGauge > maxGauge)
            {
                currGauge = maxGauge;
            }

            SetGauge(currGauge);
            yield return null;
        }

        OnOver_Gauge?.Invoke();
        yield break;
    }

    IEnumerator IncreaseDecay()
    {
        yield return null;

        yield return new WaitUntil(() => scoreManage.score > 100);
        gaugeDecay = 0.2f;

        yield return new WaitUntil(() => scoreManage.score > 200);
        gaugeDecay = 0.24f;

        yield return new WaitUntil(() => scoreManage.score > 300);
        gaugeDecay = 0.28f;

        yield return new WaitUntil(() => scoreManage.score > 500);
        gaugeDecay = 0.34f;

        yield break;
    }

    void RegainGauge()
    {
        currGauge += gaugeRegain;
    }

    void SetGauge(float gauge)
    {
        gaugeRatio = currGauge / maxGauge;
    }
}
