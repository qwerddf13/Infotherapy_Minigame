using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NeedleMove : MonoBehaviour
{
    public int maxDegree = 60;
    public int absNeedleSpeed = 10;
    int needleDirection = -1;


    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, maxDegree);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, absNeedleSpeed * needleDirection) * Time.deltaTime);
        ChangeDirection();
        Debug.Log(transform.rotation.eulerAngles.z);
    }

    void ChangeDirection()
    {
        if (transform.rotation.eulerAngles.z >= maxDegree)
        {
            transform.rotation = Quaternion.Euler(0, 0, maxDegree);
            needleDirection = -1;
            Debug.Log("방향이 시계방향(-1)로 바뀜");
        }
        else if (transform.rotation.eulerAngles.z <= -maxDegree)
        {
            transform.rotation = Quaternion.Euler(0, 0, -maxDegree);
            needleDirection = 1;
            Debug.Log("방향이 반시계방향(1)로 바뀜");
        }
    }
}
