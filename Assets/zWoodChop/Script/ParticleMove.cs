using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class ParticleMove : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    Material originMaterial;
    public Material flashMaterial;

    void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, 4)];

        transform.position = new Vector2(Random.Range(-1.0f, 1.0f), transform.position.y);

        originMaterial = spriteRenderer.material;
        
        StartCoroutine(DoFall(Random.Range(-4.0f, 4.0f)));
    }

    void Update()
    {

    }
    
    IEnumerator DoFall(float randomX) // Random.Range
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(0.01f);
        spriteRenderer.material = originMaterial;

        float gravity = Random.Range(1f, 10.0f);
        yield return null;

        while (transform.position.y > -3.125)
        {
            gravity -= 30f * Time.deltaTime;
            transform.Translate(new Vector2(randomX, gravity) * Time.deltaTime);
            yield return null;
        }

        transform.position = new Vector2(transform.position.x, -3.125f);

        for (int i = 0; i < Random.Range(20, 100); i++)
        {
            transform.Translate(new Vector2(randomX * 0.1f, 0) * Time.deltaTime);
            yield return null;
        }

        Destroy(gameObject);
        yield break;
    }
}
