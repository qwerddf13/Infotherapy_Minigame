using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopSoundManage : MonoBehaviour
{
    public Sound sound1;
    public Sound sound2;

    void Start()
    {
        sound1.SetTimeSoundInScript(0.1f);
        sound2.SetTimeSoundInScript(0.4f);
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
            sound1.SetSoundPitchInScript(1.04f);
        }
        else
        {
            sound1.SetSoundPitchInScript(1.0f);
        }

        sound1.PlaySoundInScript();

        sound2.SetSoundPitchInScript(Random.Range(0.90f, 1.0f));
        sound2.PlaySoundInScript();
    }
}
