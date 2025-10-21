using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class EndCard : MonoBehaviour
{
    public Image endCard;

    void Start()
    {
        
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

    IEnumerator DoEndCardAppear()
    {
        yield return new WaitForSeconds(2);

        for (float i = 0f; i < 0.7f; i += 0.7f * Time.deltaTime)
        {
            endCard.color = new Color(0, 0, 0, i);
            yield return null;
        }

        endCard.color = new Color(0, 0, 0, 0.7f);

        yield break;
    }
}
