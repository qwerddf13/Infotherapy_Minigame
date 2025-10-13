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
        
    }
}
