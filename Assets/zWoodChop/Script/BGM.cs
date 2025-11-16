using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public GameManage gameManage;
    public AudioSource BGSound;

    void Start()
    {
        StartCoroutine(DoPlayBGM());
    }

    void Update()
    {

    }
    
    IEnumerator DoPlayBGM()
    {
        yield return new WaitUntil(() => gameManage.isGameRunning == true);

        BGSound.loop = true;
        BGSound.Play();

        yield return new WaitUntil(() => gameManage.isGameRunning == false);

        BGSound.Stop();

        yield break;
    }
}
