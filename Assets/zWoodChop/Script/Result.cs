using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Result : MonoBehaviour
{
    public GameObject resultBox;
    public RectTransform rectTransform;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnEnable()
    {
        GameManage.OnGameOver += ShowResult;
    }

    void ShowResult()
    {
        LeanTween.moveY(rectTransform, 0, 2f).setEase(LeanTweenType.easeOutQuint).setDelay(3f);
    }
}
