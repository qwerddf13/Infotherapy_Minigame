using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class ResultScore : MonoBehaviour
{
    public TMP_Text resultScoreText;
    public ScoreManage scoreManage;

    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnEnable()
    {
        GameManage.OnGameOver += () => StartCoroutine(DoShowScore());
    }

    IEnumerator DoShowScore()
    {
        resultScoreText.text = "0";

        yield return new WaitForSeconds(4.5f);

        for (int i = 0; i <= 120; i++)
        {
            if (i <= scoreManage.score)
                break;
                
            resultScoreText.text = $"{i}";
            yield return null;
        }

        resultScoreText.text = $"{scoreManage.score}";

        yield break;
    }
}
