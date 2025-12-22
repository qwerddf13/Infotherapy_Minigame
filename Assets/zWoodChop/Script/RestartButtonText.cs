using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RestartButtonText : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] Button button;
    void Start()
    {
        button.onClick.AddListener(() => Coin.coinAmount--);
    }

    void Update()
    {
        text.text = $"다시 시작\n(현재 코인: {Coin.coinAmount})";
    }
}
