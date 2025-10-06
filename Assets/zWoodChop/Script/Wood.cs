
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    int woodNum;
    int spriteNum;
    void Start()
    {
        SpawnWood spawnWood = GameObject.Find("WoodSpawner").GetComponent<SpawnWood>();
        woodNum = spawnWood.toSetWoodNum;
        spriteNum = spawnWood.toSetSpriteNum;
        spriteRenderer.sprite = sprites[spriteNum];
    }

    void Update()
    {

    }

    void OnEnable()
    {
        Player.OnCutWood += GetChop;
    }

    void OnDisable()
    {
        Player.OnCutWood -= GetChop;
    }

    void GetChop()
    {
        if (woodNum == 1)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(DoCuttingFall());
            woodNum--;
        }
    }

    IEnumerator DoCuttingFall()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.Translate(new Vector2(0, -0.1f));
            yield return null;
        }

        yield break;
    }
}