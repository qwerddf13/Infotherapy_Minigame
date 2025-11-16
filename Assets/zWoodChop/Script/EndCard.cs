using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class EndCard : MonoBehaviour
{
    public Image endCard;

    void Awake()
    {
        endCard.color = new Color(0, 0, 0, 1.0f);
    }

    void Start()
    {
        StartCoroutine(DoEndCardDisappear());
    }

    void Update()
    {

    }

    void OnEnable()
    {
        GameManage.OnGameOver += () => StartCoroutine(DoEndCardAppear());
    }

    void OnDisable()
    {

    }

    IEnumerator DoEndCardDisappear()
    {
        yield return new WaitForSeconds(0.5f);

        for (float i = 1.0f; i >= 0f; i -= 1.0f * Time.deltaTime)
        {
            endCard.color = new Color(0, 0, 0, i);
            yield return null;
        }

        endCard.color = new Color(0, 0, 0, 0.0f);

        yield break;
    }

    IEnumerator DoEndCardAppear()
    {
        yield return new WaitForSeconds(2);

        for (float i = 0f; i < 0.9f; i += 0.8f * Time.deltaTime)
        {
            endCard.color = new Color(0, 0, 0, i);
            yield return null;
        }

        endCard.color = new Color(0, 0, 0, 0.9f);

        yield break;
    }
}
