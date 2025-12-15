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
        EndCardDisappear();
    }

    void Update()
    {

    }

    void OnEnable()
    {
        GameManage.OnGameOver += EndCardAppear;
    }

    void OnDisable()
    {

    }

    void EndCardDisappear()
    {
        LeanTween.alpha(gameObject, 0.9f, 1f).setDelay(0.5f);
    }

    void EndCardAppear()
    {
        LeanTween.alpha(gameObject, 0.9f, 1f).setDelay(2f);
    }
}
