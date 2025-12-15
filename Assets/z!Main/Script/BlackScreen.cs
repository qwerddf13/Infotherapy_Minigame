using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    public Image blackScreen;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClickGameStart()
    {
        StartCoroutine(DoBlackScreenAppear());
    }

    IEnumerator DoBlackScreenDisappear()
    {
        yield return new WaitForSeconds(0.5f);

        for (float i = 1.0f; i >= 0f; i -= 1.0f * Time.deltaTime)
        {
            blackScreen.color = new Color(0, 0, 0, i);
            yield return null;
        }

        blackScreen.color = new Color(0, 0, 0, 0.0f);

        yield break;
    }

    IEnumerator DoBlackScreenAppear()
    {
        yield return new WaitForSeconds(0.5f);

        for (float i = 0f; i <= 1f; i += 1f * Time.deltaTime)
        {
            blackScreen.color = new Color(0, 0, 0, i);
            yield return null;
        }

        blackScreen.color = new Color(0, 0, 0, 1f);

        yield break;
    }
}
