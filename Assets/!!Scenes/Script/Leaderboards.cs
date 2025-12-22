using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Services.Leaderboards;
using Unity.Services.Authentication;
using System;
using Unity.Services.Core;
using System.Threading.Tasks;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;

public class Leaderboards : MonoBehaviour
{
    public TMP_InputField schoolNumInput;

    static string schoolNum;

    async void Awake()
    {
        await UnityServices.InitializeAsync();

        DontDestroyOnLoad(gameObject);
    }


    public async Task SignUpOrInWithUsernameAndPasswordAsync(string username, string password)
    {
        schoolNum = username;
        AuthenticationService.Instance.SignOut();

        try
        {
            await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(username, password);
            Debug.Log("회원가입 성공!");
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");
        }
        catch (AuthenticationException ex)
        {
            Debug.LogWarning("회원가입 실패: " + ex.Message);
            await SignInWithUsernameAndPasswordAsync(username, password);
        }
        catch (RequestFailedException ex)
        {
            Debug.LogError("요청 실패: " + ex.Message);
        }
    }

    public async Task SignInWithUsernameAndPasswordAsync(string username, string password)
    {
        AuthenticationService.Instance.SignOut();

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

    public void SignOut()
    {
        AuthenticationService.Instance.SignOut();
    }

    async public Task SubmitScore(string leaderboards, int score)
    {
        try
        {
            await LeaderboardsService.Instance.AddPlayerScoreAsync(
                leaderboards, 
                score,
                new AddPlayerScoreOptions
                {
                    Metadata = new Dictionary<string, string>
                    {
                        {"num", schoolNum}
                    }
                }
            );
                
            Debug.Log($"점수 제출. 이름: {schoolNum}, 점수:{score}");
        }
        catch (Exception e)
        {
            Debug.LogError($"니ㅈ댐:{e.Message}");
        }
    }
}
