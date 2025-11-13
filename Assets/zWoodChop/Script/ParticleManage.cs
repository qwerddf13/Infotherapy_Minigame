using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManage : MonoBehaviour
{
    public GameObject chopParticle;
    void Start()
    {
        
    }

    void Update()
    {

    }
    void OnEnable()
    {
        Player.OnCutWood += SpawnParticle;
    }

    void OnDisable()
    {
        Player.OnCutWood -= SpawnParticle;
    }

    void SpawnParticle(bool _)
    {
        for (int i = 0; i < 7; i++) 
        { 
            Instantiate(chopParticle);
        }
    }
}
