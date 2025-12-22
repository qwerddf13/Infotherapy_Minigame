using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rank : MonoBehaviour
{
    [SerializeField] TMP_Text rankText;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text scoretext;
    [SerializeField] int myNum;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnEnable()
    {
        GameManage.OnGameOver += WriteLeaderboard;
    }

    void OnDisable()
    {
        GameManage.OnGameOver -= WriteLeaderboard;
    }

    void WriteLeaderboard()
    {
        
    }
}
