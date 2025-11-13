using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopSoundManage : MonoBehaviour
{
    public AudioSource audioSource;
    void Start()
    {
        audioSource.time = 0.1f;
    }

    void Update()
    {

    }

    void OnEnable()
    {
        GaugeManage.OnIsPerfectChop += SoundChop;
    }
    
    void SoundChop(bool isPerfect)
    {
        if (isPerfect == true)
        {
            audioSource.pitch = 1.04f;
        }
        else
        {
            audioSource.pitch = 1.0f;
        }

        audioSource.PlayOneShot(audioSource.clip);
    }
}
