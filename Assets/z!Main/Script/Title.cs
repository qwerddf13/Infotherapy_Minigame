using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    void Start()
    {
        LeanTween.moveLocalY(gameObject, 140, 1.5f).setEase(LeanTweenType.easeInOutSine).setLoopCount(-1).setLoopPingPong();
    }
}
