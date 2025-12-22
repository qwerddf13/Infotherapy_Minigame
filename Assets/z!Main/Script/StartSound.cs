using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSound : MonoBehaviour
{
    [SerializeField] AudioSource mainBGM;
    [SerializeField] AudioSource startSound;
    
    public void StopBGMAndStartSound()
    {
        mainBGM.Stop();
        startSound.Play();
    }
}
