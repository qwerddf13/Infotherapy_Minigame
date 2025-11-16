using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Result : MonoBehaviour
{
    public RectTransform rectTransform;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnEnable()
    {
        GameManage.OnGameOver += () => StartCoroutine(DoShowResult());
    }

    IEnumerator DoShowResult()
    {
        rectTransform.anchoredPosition = new Vector2(0, -900);

        yield return new WaitForSeconds(3);

        for (int i = 0; i < 450; i++){
            rectTransform.anchoredPosition += new Vector2(0, 2f);
            yield return null;
        }

        for (int i = 0; i < 100; i++){
            rectTransform.anchoredPosition += new Vector2(0, 0.1f);
            yield return null;
        }

        for (int i = 0; i < 100; i++){
            rectTransform.anchoredPosition += new Vector2(0, -0.1f);
            yield return null;
        }

        yield break;
    }
}
