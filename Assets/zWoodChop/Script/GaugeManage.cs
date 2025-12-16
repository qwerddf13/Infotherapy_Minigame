using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeManage : MonoBehaviour
{
    public ScoreManage scoreManage;
    public GameManage gameManage;

    public float maxGauge = 1000;
    public float currGauge = 1000;
    float gaugeDecay = 100f;
    float gaugeRegain = 70;
    public float gaugeRatio = 1.0f;

    void Start()
    {
        StartCoroutine(DoGaugeDecay());
        StartCoroutine(IncreaseDecay());
    }

    void Update()
    {

    }

    public static event Action OnOver_Gauge;
    public static event Action<bool> OnIsPerfectChop;

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
        yield return new WaitUntil(() => gameManage.isGameRunning == true);

        while (currGauge > 0 && gameManage.isGameRunning)
        {
            currGauge -= gaugeDecay * Time.deltaTime; //Update에서 * Time.deltaTime;

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
        gaugeDecay = 200f;

        yield return new WaitUntil(() => scoreManage.score > 100);
        gaugeDecay = 300f;

        yield return new WaitUntil(() => scoreManage.score > 200);
        gaugeDecay = 370f;

        yield return new WaitUntil(() => scoreManage.score > 300);
        gaugeDecay = 440f;

        yield return new WaitUntil(() => scoreManage.score > 500);
        gaugeDecay = 500f;

        yield return new WaitUntil(() => scoreManage.score > 600);
        gaugeDecay = 570f;

        yield return new WaitUntil(() => scoreManage.score > 700);
        gaugeDecay = 640f;

        yield break;
    }

    void RegainGauge(bool _)
    {
        currGauge += gaugeRegain;

        if (currGauge >= maxGauge)
        {
            currGauge = maxGauge;
            OnIsPerfectChop?.Invoke(true);
        }
        else
        {
            OnIsPerfectChop?.Invoke(false);
        }
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
