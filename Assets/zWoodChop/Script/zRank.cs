using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Unity.Services.Leaderboards;
using TMPro;
using System.Threading.Tasks;
using System.Text;

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
        GameManage.OnGameOver += async () => await BeforeWriteLeaderboard();
    }

    async Task BeforeWriteLeaderboard()
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

        await WriteLeaderboard(rankNum);
    }

    async Task WriteLeaderboard(int rank)
    {
        try
        {
            var myScore = await LeaderboardsService.Instance.GetScoresAsync("CuttingWoods", new GetScoresOptions
            {
                Limit = 1, Offset = rank, IncludeMetadata = true
            });

            string schoolNum = myScore.Results[0].Metadata;

            var meta = JsonUtility.FromJson<RankMetadata>(schoolNum);

            string num = meta.num;
            
            if (myScore != null && myScore.Results.Count > 0)
            {
                rankText.text = $"{rank + 1}위";
                nameText.text = $"{num}";
                scoreText.text = $"{myScore.Results[0].Score}점";
            }
            else
            {
                rankText.text = "";
                nameText.text = "";
                scoreText.text = "";
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

