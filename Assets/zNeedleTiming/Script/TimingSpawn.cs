using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingSpawn : MonoBehaviour
{
    public GameObject timingBlock;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            SpawnBlock(true);
        }
    }

    void OnEnable()
    {
        NeedleMove.OnIsNeedleGoingRight += SpawnBlock;
    }

    void OnDisable()
    {
        NeedleMove.OnIsNeedleGoingRight -= SpawnBlock;
    }

    void SpawnBlock(bool IsGoingRight)
    {
        if (IsGoingRight)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(-40.0f, 0)));
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 40.0f)));
        }

        Instantiate(timingBlock, gameObject.transform.position, gameObject.transform.rotation);
    }
}
