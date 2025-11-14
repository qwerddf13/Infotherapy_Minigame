using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopSoundManage : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    void Start()
    {
        audioSource1.time = 0.1f;
        audioSource2.time = 0.4f;
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
            audioSource1.pitch = 1.04f;
        }
        else
        {
            audioSource1.pitch = 1.0f;
        }

        audioSource1.PlayOneShot(audioSource1.clip);

        audioSource2.pitch = Random.Range(0.90f, 1.0f);
        audioSource2.PlayOneShot(audioSource2.clip);
    }
}
