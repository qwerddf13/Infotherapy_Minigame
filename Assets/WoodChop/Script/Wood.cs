
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
            Debug.Log("나무 잘림. 점수 상승.");
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(new Vector2(0, -1));
            woodNum--;
        }
    }
}