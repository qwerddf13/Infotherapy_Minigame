using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TimingBlock : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        gameObject.transform.Translate(Vector2.up * 6.2f);
    }


    void Update()
    {
        
    }

    void OnEnable()
    {
        NeedleMove.OnIsNeedleGoingRight += ChangeState;
    }

    void OnDisable()
    {
        NeedleMove.OnIsNeedleGoingRight -= ChangeState;
    }

    void ChangeState(bool _)
    {
        if (spriteRenderer.color.a <= 0.5f)
        {
            spriteRenderer.color = new Color(0.2f, 1f, 0f, 1);
        }
        else if (spriteRenderer.color.a == 1f)
        {
            Destroy(gameObject);
        }
    }
}
