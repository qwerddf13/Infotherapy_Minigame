using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInMain : MonoBehaviour
{
    public void MoveUpward()
    {
        LeanTween.moveLocalY(gameObject, transform.localPosition.y + 1000, 1f).setEase(LeanTweenType.easeOutQuint);
    }

    public void MoveDownward()
    {
        LeanTween.moveLocalY(gameObject, transform.localPosition.y - 1000, 1f).setEase(LeanTweenType.easeOutQuint);
    }
}
