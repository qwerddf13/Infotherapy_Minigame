using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public TMP_Text scoreText;

    public ScoreManage scoreManage;

    void Start()
    {
    }

    void Update()
    {
        scoreText.text = $"Score: {scoreManage.score}";
    }

}
