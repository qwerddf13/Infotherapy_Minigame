
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    Material originMaterial;
    public Material flashMaterial;

    public Sprite[] sprites;
    int woodNum;
    int spriteNum;
    void Start()
    {
        SpawnWood spawnWood = GameObject.Find("WoodSpawner").GetComponent<SpawnWood>();
        originMaterial = spriteRenderer.material;

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
        spriteRenderer.sortingOrder -= 1;

        if (woodNum == 1)
        {
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
        yield return new WaitForSeconds(0.01f);

        transform.Translate(new Vector2(0, -1));
        
        yield break;
    }

    IEnumerator DoChoppedFall(int direction_X)
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.95f);

        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(0.01f);
        spriteRenderer.material = originMaterial;

        float gravity = 10;

        while (transform.position.y > -7)
        {
            gravity -= 25f * Time.deltaTime;
            transform.Translate(new Vector2(6 * direction_X, gravity) * Time.deltaTime);
            yield return null;
        }

        Destroy(gameObject);
        yield break;
    }
}