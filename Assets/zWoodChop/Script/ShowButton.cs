using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButton : MonoBehaviour
{
    public RectTransform rectTransform;

    void OnEnable()
    {
        GameManage.OnGameOver += ButtonShow;
    }

    void OnDisable()
    {
        GameManage.OnGameOver -= ButtonShow;
    }

    void ButtonShow()
    {
        LeanTween.moveY(rectTransform, -300f, 2f).setEase(LeanTweenType.easeOutQuint).setDelay(3f);
    }
}
