using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    //static bool hasInstance;

    /*void Awake()
    {
        if (hasInstance)
        {
            Destroy(gameObject);
        }
        else
        {
            hasInstance = true;
            DontDestroyOnLoad(gameObject);
        }
    }*/

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    public void SetSoundPitchInScript(float num)
    {
        audioSource.pitch = num;
    }

    public void SetTimeSoundInScript(float num)
    {
        audioSource.time = num;
    }

    public void PlaySoundInScript()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}
