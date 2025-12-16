using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NeedleMove : MonoBehaviour
{
    public int maxDegree = 60;
    public int absNeedleSpeed = 10;
    int needleDirection = -1;
    bool isGameRunning = true;


    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, maxDegree);
        StartCoroutine(DoChangeDirection());
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, absNeedleSpeed * needleDirection) * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            isGameRunning = false;
        }
    }

    public static event Action<bool> OnIsNeedleGoingRight;

    IEnumerator DoChangeDirection()
    {
        while (isGameRunning)
        {
            yield return new WaitUntil(() => transform.rotation.eulerAngles.z < (360 - maxDegree) && transform.rotation.eulerAngles.z > 180);
            transform.rotation = Quaternion.Euler(0, 0, 360 - maxDegree);
            needleDirection = 1;
            OnIsNeedleGoingRight?.Invoke(true);
            Debug.Log("방향이 반시계방향(1)로 바뀜");

            yield return new WaitUntil(() => transform.rotation.eulerAngles.z > maxDegree && transform.rotation.eulerAngles.z < 180);
            transform.rotation = Quaternion.Euler(0, 0, maxDegree);
            needleDirection = -1;
            OnIsNeedleGoingRight?.Invoke(false);
            Debug.Log("방향이 시계방향(-1)로 바뀜");
        }
        yield break;
    }
}
