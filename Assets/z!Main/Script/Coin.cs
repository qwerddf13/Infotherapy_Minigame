using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Search;

public class Coin : MonoBehaviour
{
    [SerializeField] TMP_InputField realText;
    [SerializeField] TMP_Text coinText1;
    [SerializeField] TMP_Text coinText2;
    [SerializeField] TMP_Text toInsertCoinText;

    [SerializeField] Button acceptButton;

    public static int coinAmount = 0;
    public int toInsertCoin;

    void Awake()
    {
        toInsertCoin = 3;
    }

    void Update()
    {
        coinText1.text = $"현재 코인: {coinAmount}";
        coinText2.text = $"현재 코인: {coinAmount}";
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
        realText.text = "";
        acceptButton.interactable = false;
    }
}
