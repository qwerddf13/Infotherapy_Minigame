using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManage : MonoBehaviour
{
    public int score = 0;
    void Start()
    {

    }

    void Update()
    {

    }

    void OnEnable()
    {
        Player.OnCutWood += PlusScore;
    }

    void OnDisable()
    {
        Player.OnCutWood += PlusScore;
    }

    void PlusScore(bool _)
    {
        score++;
    }
}
