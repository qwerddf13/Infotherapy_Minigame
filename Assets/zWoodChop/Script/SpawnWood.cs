using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnWood : MonoBehaviour
{
    public GameObject woodPrefab;

    public int maxWoodAmount = 10;
    public int toSetWoodNum = 0;
    public int toSetSpriteNum = 0;
    public List<int> woodNums = new List<int> {0};

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

    public void DoSpawnWood(bool _)
    {
        if (woodNums.Count >= 10)
            woodNums.RemoveAt(0);
        
        if (toSetSpriteNum == 2 || toSetSpriteNum == 3)
        {
            toSetSpriteNum = Random.Range(0, 2);
        }
        else
        {
            toSetSpriteNum = Random.Range(0, 4);
        }
        woodNums.Add(toSetSpriteNum);
        
        Instantiate(woodPrefab, transform.position, transform.rotation);
    }

    IEnumerator DoSettingSpawn()
    {
        for (int i = 0; i < 2; i++)
        {
            transform.Translate(new Vector2(0, 1));
            toSetWoodNum++;
            DoSpawnWood(true);
            yield return null;
        }

        for (int i = 0; i < maxWoodAmount - 2; i++)
        {
            transform.Translate(new Vector2(0, 1));
            toSetWoodNum++;
            DoSpawnWood(true);
            yield return null;
        }
        Debug.Log(string.Join(",", woodNums));
        yield break;
    }
}
