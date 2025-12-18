using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public int sceneNum = 0; // 이건 GameSelect에 의해 설정됨!

    void Start()
    {
        
    }

    void Update()
    {
        
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
                Debug.Log("잘못된 게임 번호입니다.");
                break;
        }

    }
}
