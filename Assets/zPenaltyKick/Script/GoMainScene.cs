using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMainScene : MonoBehaviour
{
    public void GameScenesCtrl()
    {
        SceneManager.LoadScene("!Main");
    }
}