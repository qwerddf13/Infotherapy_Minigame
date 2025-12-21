using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Services.Leaderboards;
using Unity.Services.Authentication;
using System;
using Unity.Services.Core;
using System.Threading.Tasks;
using TMPro;

public class Leaderboards : MonoBehaviour
{
    public TMP_InputField schoolNumInput;

    async void Start()
    {
        await UnityServices.InitializeAsync();
        
        schoolNumInput.onEndEdit.AddListener(async (value) => await SignUpWithUsernameAndPasswordAsync(schoolNumInput.text, $"Aa@{schoolNumInput.text}"));
        schoolNumInput.onEndEdit.AddListener(async (value) => await SignInWithUsernameAndPasswordAsync(schoolNumInput.text, $"Aa@{schoolNumInput.text}"));
    }

    public async Task SignInWithUsernameAndPasswordAsync(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(username, password);
            Debug.Log("로그인 성공!");
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");
        }
        catch (AuthenticationException ex)
        {
            Debug.LogError("인증 실패: " + ex.Message);
        }
        catch (RequestFailedException ex)
        {
            Debug.LogError("요청 실패: " + ex.Message);
        }
    }


    public async Task SignUpWithUsernameAndPasswordAsync(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(username, password);
            Debug.Log("회원가입 성공!");
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");
        }
        catch (AuthenticationException ex)
        {
            Debug.LogError("회원가입 실패: " + ex.Message);
        }
        catch (RequestFailedException ex)
        {
            Debug.LogError("요청 실패: " + ex.Message);
        }
    }

    async public void SubmitScore(string leaderboards, string name, int score)
    {
        try
        {
            await LeaderboardsService.Instance.AddPlayerScoreAsync(leaderboards, score);
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
