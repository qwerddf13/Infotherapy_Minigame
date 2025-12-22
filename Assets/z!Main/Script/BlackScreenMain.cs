using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreenMain : MonoBehaviour
{
    public RectTransform blackScreen;
    [SerializeField] Image image;

    void Awake()
    {
        image.color = new Color(0, 0, 0, 1f);
    }

    void Start()
    {
        BlackScreenDisappear();
    }

    public void BlackScreenDisappear()
    {
        LeanTween.color(blackScreen, new Color(0, 0, 0, 0f), 1f).setFromColor(new Color(0, 0, 0, 1f));
    }

    public void BlackScreenAppear()
    {
        LeanTween.color(blackScreen, new Color(0, 0, 0, 1f), 1f);
    }
}
