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

        while (rectTransform.anchoredPosition.y <= 0)
        {
            rectTransform.anchoredPosition += new Vector2(0, 800f) * Time.deltaTime;
            yield return null;
        }

        while (rectTransform.anchoredPosition.y <= 30)
        {
            rectTransform.anchoredPosition += new Vector2(0, 100f) * Time.deltaTime;
            yield return null;
        }

        while (rectTransform.anchoredPosition.y >= 0)
        {
            rectTransform.anchoredPosition += new Vector2(0, -100f) * Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = new Vector2(0, 0);

        yield break;
    }
}
