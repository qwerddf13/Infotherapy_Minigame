using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI를 쓸 경우 필요

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int currentScore = 0;

    void Awake() { instance = this; }

    public void AddScore(int amount)
    {
        currentScore += amount;
        Debug.Log("점수: " + currentScore);
    }
}