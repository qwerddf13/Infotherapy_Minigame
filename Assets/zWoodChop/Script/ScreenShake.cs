using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeAmount;
    public float shakeTime;
    Vector3 initialPos;

    void Start()
    {
        initialPos = new Vector3(0, 0, -10);
    }

    void Update()
    {
        if (shakeTime > 0)
        {
            transform.position = initialPos;
            transform.position = Random.insideUnitSphere * shakeAmount;
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            shakeTime -= Time.unscaledDeltaTime;
        }
        else
        {
            shakeTime = 0f;
            transform.position = initialPos;
        }
    }

    public void ShakeForTime(float time)
    {
        shakeTime = time;
    }
}
