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
        try
        {
            var myScore = await LeaderboardsService.Instance.GetScoresAsync(sceneName, new GetScoresOptions
            {
                Limit = 3, Offset = rank - 1, IncludeMetadata = true
            });

            string schoolNum = myScore.Results[0].Metadata;

            var meta = JsonUtility.FromJson<RankMetadata>(schoolNum);

            string num = meta.num;
            
            if (myScore != null && myScore.Results.Count > 0)
            {
                for (int i = 0; i < myScore.Results.Count; i++)
                {
                    var score = myScore.Results[i];

                    switch (i)
                    {
                        case 0:
                            rankText1.text = (i + 1).ToString();
                            nameText1.text = num;
                            scoreText1.text = score.Score.ToString();
                            break;
                        case 1:
                            rankText2.text = (i + 1).ToString();
                            nameText2.text = num;
                            scoreText3.text = score.Score.ToString();
                            break;
                        case 2:
                            rankText3.text = (i + 1).ToString();
                            nameText3.text = num;
                            scoreText3.text = score.Score.ToString();
                            break;
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
        catch (Exception e)
        {
            Debug.LogWarning($"리더보드 데이터를 가져오는 중 오류가 발생했습니다: {e.Message}");
        }
    }
}

