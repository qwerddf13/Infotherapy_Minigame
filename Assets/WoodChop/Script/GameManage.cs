using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    void Start()
    {

    }


    void Update()
    {

    }

    public static event Action OnGameOver;

    void OnEnable()
    {
        Player.OnOver_Player += () => OnGameOver?.Invoke();
        GaugeManage.OnOver_Gauge += () => OnGameOver?.Invoke();
    }

    void OnDisable()
    {
        Player.OnOver_Player -= () => OnGameOver?.Invoke();
        GaugeManage.OnOver_Gauge -= () => OnGameOver?.Invoke();
    }
}
