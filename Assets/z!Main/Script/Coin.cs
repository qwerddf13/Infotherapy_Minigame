using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Coin : MonoBehaviour
{
    [SerializeField] TMP_InputField realText;
    [SerializeField] TMP_Text coinText1;
    [SerializeField] TMP_Text coinText2;
    [SerializeField] TMP_Text toInsertCoinText;

    [SerializeField] Button acceptButton;
    
    [SerializeField] AudioSource insertCoinSound;

    public static int coinAmount = 1;///////////////////////////////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//////////////////////////////
    public int toInsertCoin;

    void Awake()
    {
        toInsertCoin = 3;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (coinText1 != null){
            coinText1.text = $"현재 코인: {coinAmount}";
            coinText2.text = $"현재 코인: {coinAmount}";
            toInsertCoinText.text = $"{toInsertCoin}";
        }
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
        insertCoinSound.Play();

        coinAmount += toInsertCoin;
        realText.text = "";
        acceptButton.interactable = false;
    }

    public void UseCoin()
    {
        coinAmount--;
    }
}
