using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Unity.Services.Leaderboards;
using TMPro;
using System.Threading.Tasks;

public class Rank : MonoBehaviour
{
    [SerializeField] TMP_Text rankText;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Leaderboards leaderboards;
    [SerializeField] ScoreManage scoreManage;
    [SerializeField] int myNum;
    int rankNum;

    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnEnable()
    {
        GameManage.OnGameOver += async () => await WriteLeaderboard(rankNum);
    }

    async Task WriteLeaderboard(int rank)
    {
        if (leaderboards != null)
        try
        {
            await leaderboards.SubmitScore("CuttingWoods", scoreManage.score);
        }
        catch (Exception ex)
        {
            Debug.LogError($"오류남ㅅㄱ: {ex.Message}");
        }
        
        var myRank = await LeaderboardsService.Instance.GetPlayerScoreAsync("CuttingWoods");
        rankNum = myRank.Rank + myNum;

        try
        {
            var myScore = await LeaderboardsService.Instance.GetScoresAsync("CuttingWoods", new GetScoresOptions
            {
                Limit = 1, Offset = rank
            });

            if (myScore != null && myScore.Results.Count > 0)
            {
                rankText.text = $"{rank + 1}";
                nameText.text = $"{myScore.Results[0].Metadata}";
                scoreText.text = $"{myScore.Results[0].Score}";
            }
            else
            {
                Debug.Log("리더보드에 데이터가 없습니다.");
            }
        }
        catch (Exception e)
        {
            rankText.text = "";
            nameText.text = "";
            scoreText.text = "";
            Debug.LogWarning($"리더보드 데이터를 가져오는 중 오류가 발생했습니다: {e.Message}");
        }
    }
}

