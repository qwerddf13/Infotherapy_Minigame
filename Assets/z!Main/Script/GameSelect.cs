using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSelect : MonoBehaviour
{
    [SerializeField] GameDescription gameDescription;
    [SerializeField] TMP_Text header;
    [SerializeField] TMP_Text content;

    [SerializeField] Button[] otherSelectButton;
    [SerializeField] Button startButton;
    public static int myNum = 0;

    [SerializeField] GameObject descriptionContainer;

    bool isShowingDescription;

    [SerializeField] GameStart gameStart;

    public void ShowAndHideDescription(int num)
    {
        if (! isShowingDescription)
        {
            isShowingDescription = true;
            gameStart.sceneNum = num;

            foreach(Button otherButton in otherSelectButton)
            {
                otherButton.interactable = false;
            }

            if (Coin.coinAmount > 0)
                startButton.interactable = true;

            header.text = gameDescription.header;
            content.text = gameDescription.content;

            gameObject.transform.SetAsLastSibling();

            LeanTween.cancel(gameObject);
            LeanTween.moveLocalX(gameObject, -400, 1f).setEase(LeanTweenType.easeOutQuint).setFrom(-630 + 420 * num).setDelay(0.06f);
            LeanTween.scale(gameObject, new Vector2(1.1f, 1.1f), 1f).setEase(LeanTweenType.easeOutQuint).setDelay(0.06f);

            LeanTween.cancel(descriptionContainer);
            LeanTween.moveLocalX(descriptionContainer, 250, 1f).setEase(LeanTweenType.easeOutQuint).setFrom(1400).setDelay(0.06f);
            LeanTween.scale(descriptionContainer, new Vector2(1.1f, 1.1f), 1f).setEase(LeanTweenType.easeOutQuint).setDelay(0.06f);
        }
        else
        {
            HideDescription(num);
        }
    }

    public void HideDescription(int num)
    {
        isShowingDescription = false;

        foreach(Button otherButton in otherSelectButton)
        {
            otherButton.interactable = true;
        }

        startButton.interactable = false;

        LeanTween.cancel(gameObject);
        LeanTween.moveLocalX(gameObject, -630 + 420 * num, 1f).setEase(LeanTweenType.easeOutQuint);
        LeanTween.scale(gameObject, new Vector2(1f, 1f), 1f).setEase(LeanTweenType.easeOutQuint); 

        LeanTween.cancel(descriptionContainer);
        LeanTween.moveLocalX(descriptionContainer, 1400, 1f).setEase(LeanTweenType.easeOutQuint);
        LeanTween.scale(descriptionContainer, new Vector2(1f, 1f), 1f).setEase(LeanTweenType.easeOutQuint);
    }
}
