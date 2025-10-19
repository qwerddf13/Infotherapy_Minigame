using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        Player.OnCutWood += DeActiveThis;
    }

    void OnDisable()
    {
        Player.OnCutWood -= DeActiveThis;
    }

    void DeActiveThis(bool _)
    {
        gameObject.SetActive(false);
    }
}
