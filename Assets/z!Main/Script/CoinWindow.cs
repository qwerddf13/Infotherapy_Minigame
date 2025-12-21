using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinWindow : MonoBehaviour
{
    [SerializeField] GameObject coinWindow;
    [SerializeField] Coin coinScript;

    void Awake()
    {
        coinWindow.SetActive(false);
    }

    void Update()
    {
        
    }
    
    public void ShowAndHideWindow()
    {
        if (coinWindow.activeSelf)
        {
            coinWindow.SetActive(false);
        }
        else
        {
            coinScript.toInsertCoin = 3;
            coinWindow.SetActive(true);
        }
    }

    public void HideWindow()
    {
        coinWindow.SetActive(false);
    }
}
