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
    [SerializeField] TMP_Text rankText1;
    [SerializeField] TMP_Text nameText1;
    [SerializeField] TMP_Text scoreText1;
    [SerializeField] TMP_Text rankText2;
    [SerializeField] TMP_Text nameText2;
    [SerializeField] TMP_Text scoreText2;
    [SerializeField] TMP_Text rankText3;
    [SerializeField] TMP_Text nameText3;
    [SerializeField] TMP_Text scoreText3;

    [SerializeField] TMP_Text resultScore;

    [SerializeField] Leaderboards leaderboards;
    [SerializeField] int sceneNum;

    string sceneName = "!Main";
    int rankNum;

    void Start()
    {
        switch (sceneNum)
        {
            case 0:
                sceneName = "CuttingWoods";
                break;
            case 1:
                sceneName = "Fishing";
                break;
            case 2:
                sceneName = "Gogi";
                break;
            case 3:
                sceneName = "PenaltyKick";
                break;
            default:
                sceneName = "!Main";
                break;
        }
    }

    void Update()
    {
        
    }

    void OnEnable()
    {

    }

    public async Task BeforeWriteLeaderboard(int scoreNum)
    {
        resultScore.text = scoreNum.ToString();
        if (leaderboards != null)
        {
            try
            {
                await leaderboards.SubmitScore(sceneName, scoreNum);
            }
            catch (Exception ex)
            {
                Debug.LogError($"오류남ㅅㄱ: {ex.Message}");
            }
        }
        
        var myRank = await LeaderboardsService.Instance.GetPlayerScoreAsync(sceneName);
        rankNum = myRank.Rank;

        await WriteLeaderboard(rankNum);
    }

    async Task WriteLeaderboard(int rank)
    {
        if (rank <= 0)
        {
            rank = 1;
        }
        var myScore = await LeaderboardsService.Instance.GetScoresAsync(sceneName, new GetScoresOptions
        {
            Limit = 3, Offset = rank - 1, IncludeMetadata = true
        });
        
        if (myScore != null && myScore.Results.Count > 0)
        {
            for (int i = 0; i < 3; i++)
            {
                string schoolNum = myScore.Results[i].Metadata;
                var meta = JsonUtility.FromJson<RankMetadata>(schoolNum);
                string num = meta.num;

                var score = myScore.Results[i];
                Debug.Log($"순위 {i + 1}: 유저 ID = {num}, 점수 = {score.Score}");

                switch (i)
                {
                    case 0:
                        try
                        {
                            rankText1.text = $"{i + 1}위";
                            nameText1.text = $"{num}";
                            scoreText1.text = $"{score.Score}점";
                            break;
                        }
                        catch (Exception)
                        {
                            rankText1.text = "";
                            nameText1.text = "";
                            scoreText1.text = "";
                            Debug.Log("리더보드에 없어서 넘어감 (\"\")");
                            break;
                        }
                    case 1:
                        try
                        {
                            rankText2.text = $"{i + 1}위";
                            nameText2.text = $"{num}";
                            scoreText2.text = $"{score.Score}점";
                            break;
                        }
                        catch (Exception)
                        {
                            rankText2.text = "";
                            nameText2.text = "";
                            scoreText2.text = "";
                            Debug.Log("리더보드에 없어서 넘어감 (\"\")");
                            break;
                        }
                    case 2:
                        try
                        {
                            rankText3.text = $"{i + 1}위";
                            nameText3.text = $"{num}";
                            scoreText3.text = $"{score.Score}점";
                            break;
                        }
                        catch (Exception)
                        {
                            rankText3.text = "";
                            nameText3.text = "";
                            scoreText3.text = "";
                            Debug.Log("리더보드에 없어서 넘어감 (\"\")");
                            break;
                        }
                    default:
                        break;
                }
            }
        }
        else
        {
            Debug.Log("리더보드에 데이터가 없습니다.");
        }
    }
}


