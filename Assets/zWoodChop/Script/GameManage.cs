using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public bool isGameRunning = false;
    void Start()
    {

    }


    void Update()
    {

    }

    public static event Action OnGameOver;

    void OnEnable()
    {
        Debug.Log("게임매니저 구독 시도");
        Player.OnOver_Player += GeneralGameOver;
        GaugeManage.OnOver_Gauge += GeneralGameOver;
    }

    void OnDisable()
    {
        Player.OnOver_Player -= GeneralGameOver;
        GaugeManage.OnOver_Gauge -= GeneralGameOver;
    }

    

    void GeneralGameOver()
    {
        OnGameOver?.Invoke();
        isGameRunning = false;

        StartCoroutine(DoGameOverTimeStop());

        Debug.Log("메인 게임 오버.");
    }

    IEnumerator DoGameOverTimeStop()
    {
        Time.timeScale = 0.15f;
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;

        yield break;
    }
}
