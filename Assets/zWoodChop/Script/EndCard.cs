using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndCard : MonoBehaviour
{
    public RectTransform rectTransform;
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
        GameManage.OnGameOver -= EndCardAppear;
    }

    public void EndCardDisappear()
    {
        LeanTween.color(rectTransform, new Color(0, 0, 0, 0f), 1f).setDelay(0.5f).setFromColor(new Color(0, 0, 0, 1f));
    }

    public void EndCardAppear()
    {
        LeanTween.color(rectTransform, new Color(0, 0, 0, 0.9f), 1f).setDelay(1.5f).setFromColor(new Color(0, 0, 0, 0f));
    }
}
