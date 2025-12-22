using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public int sceneNum = 0; // 이건 GameSelect에 의해 설정됨!

    public void StartDoChangeScene()
    {
        StartCoroutine(DoChangeScene());
    }

    public void ChangeScene()
    {
        switch (sceneNum)
        {
            case 0:
                SceneManager.LoadScene("WoodChop");
                break;
            case 1:
                SceneManager.LoadScene("Fishing");
                break;
            case 2:
                SceneManager.LoadScene("Gogi");
                break;
            case 3:
                SceneManager.LoadScene("PenaltyKick");
                break;
            default:
                SceneManager.LoadScene("!Main");
                break;
        }

    }

    IEnumerator DoChangeScene()
    {
        yield return new WaitForSeconds(1.5f);

        ChangeScene();

        yield break;
    }
}
