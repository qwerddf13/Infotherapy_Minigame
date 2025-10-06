using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeManage : MonoBehaviour
{
    public ScoreManage scoreManage;

    public float maxGauge = 1000;
    public float currGauge = 1000;
    float gaugeDecay = 0.6f;
    float gaugeRegain = 70;
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
        GameManage.OnGameOver += GameOver;
    }

    void OnDisable()
    {
        Player.OnCutWood -= RegainGauge;
        GameManage.OnGameOver -= GameOver;
    }

    IEnumerator DoGaugeDecay()
    {
        while (currGauge > 0)
        {
            currGauge -= gaugeDecay; //Update에서 * Time.deltaTime;

            if (currGauge > maxGauge)
            {
                currGauge = maxGauge;
            }

            SetGauge(currGauge);
            yield return null;
        }

        OnOver_Gauge?.Invoke();
        Debug.Log("게이지 게임 오버.");
        yield break;
    }

    IEnumerator IncreaseDecay()
    {
        yield return null;

        yield return new WaitUntil(() => scoreManage.score > 50);
        gaugeDecay = 0.8f;

        yield return new WaitUntil(() => scoreManage.score > 100);
        gaugeDecay = 1.0f;

        yield return new WaitUntil(() => scoreManage.score > 200);
        gaugeDecay = 1.2f;

        yield return new WaitUntil(() => scoreManage.score > 300);
        gaugeDecay = 1.4f;

        yield return new WaitUntil(() => scoreManage.score > 500);
        gaugeDecay = 1.6f;

        yield return new WaitUntil(() => scoreManage.score > 600);
        gaugeDecay = 1.8f;

        yield return new WaitUntil(() => scoreManage.score > 700);
        gaugeDecay = 2.0f;

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

    void GameOver()
    {
        gaugeDecay = 0;
    }
}
