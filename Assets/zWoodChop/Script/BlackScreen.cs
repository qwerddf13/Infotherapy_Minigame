using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreenWoodChop : MonoBehaviour
{
    GameObject blackScreen;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Restart()
    {
        LeanTween.alpha(blackScreen, 1f, 1.5f);
    }
}
