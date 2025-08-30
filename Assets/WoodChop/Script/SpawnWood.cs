using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnWood : MonoBehaviour
{
    public GameObject woodPrefab;

    public int maxWoodAmount = 10;
    public int toSetWoodNum = 0;
    public int toSetSpriteNum = 0;

    void Start()
    {
        StartCoroutine(DoSettingSpawn());
    }

    void Update()
    {

    }

    void OnEnable()
    {
        Player.OnCutWood += DoSpawnWood;
    }

    void OnDisable()
    {
        Player.OnCutWood -= DoSpawnWood;
    }

    public void DoSpawnWood()
    {
        if (toSetSpriteNum == 2 || toSetSpriteNum == 3)
        {
            toSetSpriteNum = Random.Range(0, 2);
        }
        else
        {
            toSetSpriteNum = Random.Range(0, 4);
        }
        
        Instantiate(woodPrefab, transform.position, transform.rotation);
        Debug.Log("나무 생성.");
    }

    IEnumerator DoSettingSpawn()
    {
        for (int i = 0; i < maxWoodAmount; i++)
        {
            transform.Translate(new Vector2(0, 1));
            toSetWoodNum++;
            DoSpawnWood();
            yield return null;
        }
        yield break;
    }
}
