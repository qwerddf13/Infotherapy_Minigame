using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Leaderboards;
using Unity.Services.Authentication;
using System;
using Unity.Services.Core;

public class Leaderboards : MonoBehaviour
{
    async void Awake()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }
    async public void SubmitScore(string leaderboards, string name, int score)
    {
        try
        {
            await LeaderboardsService.Instance.AddPlayerScoreAsync(leaderboards, score);// public 생각
            Debug.Log($"점수 제출. 이름: {name}, 점수:{score}");

            if (name == null || score < 0)
            {
                throw new Exception("이름이 존재하지 않거나 비정상적인 점수입니다.");
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
}
