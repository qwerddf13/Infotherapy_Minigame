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
        if (Coin.coinAmount <= 0)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
        // button.onClick.AddListener(() => Coin.coinAmount--);
    }

    void Update()
    {
        text.text = $"다시 시작\n(현재 코인: {Coin.coinAmount})";
    }
}
