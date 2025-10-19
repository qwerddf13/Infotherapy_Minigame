
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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

    void GetChop(bool isPlayerFlip)
    {
        if (woodNum == 1)
        {
            spriteRenderer.sortingOrder = -1;

            if (isPlayerFlip == false)
            {
                StartCoroutine(DoChoppedFall(1));
            }
            else
            {
                StartCoroutine(DoChoppedFall(-1));
            }

            woodNum = 0;
        }
        else
        {
            if (woodNum != 0)
            {
                StartCoroutine(DoCuttingFall());
                woodNum--;
            }
        }
    }

    IEnumerator DoCuttingFall()
    {
        for (int i = 0; i < 40; i++)
        {
            transform.Translate(new Vector2(0, -0.025f));
            yield return null;
        }

        yield break;
    }

    IEnumerator DoChoppedFall(int direction_X)
    {
        float gravity = 22;
        while (transform.position.y > -7)
        {
            gravity -= 0.1f;
            transform.Translate(new Vector2(8.5f * direction_X, gravity) * Time.deltaTime);
            yield return null;
        }

        Destroy(gameObject);
        yield break;
    }
}