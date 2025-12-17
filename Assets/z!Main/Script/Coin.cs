using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Search;

public class Coin : MonoBehaviour
{
    [SerializeField] TMP_Text coinText;
    [SerializeField] TMP_Text toInsertCoinText;
    public static int coinAmount;
    public int toInsertCoin;

    void Awake()
    {
        coinAmount = 0;
        toInsertCoin = 3;
    }

    void Update()
    {
        coinText.text = $"현재 코인: {coinAmount}";
        toInsertCoinText.text = $"{toInsertCoin}";
    }

    public void IncreaseToInsertCoin()
    {
        if (toInsertCoin < 99)
        {
            toInsertCoin++;
        }
    }

    public void DecreaseToInsertCoin()
    {
        if (toInsertCoin > 0)
        {
            toInsertCoin--;
        }
    }

    public void InsertCoin()
    {
        coinAmount += toInsertCoin;
    }
}
