using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copy : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject ins = Instantiate(obj1, obj1.transform.position, obj1.transform.rotation) as GameObject;
            GameObject ins1 = Instantiate(obj2, obj2.transform.position, obj2.transform.rotation) as GameObject;
            GameObject ins2 = Instantiate(obj3, obj3.transform.position, obj3.transform.rotation) as GameObject;

        }
    }
}
