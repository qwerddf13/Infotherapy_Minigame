using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public AudioSource audioSource;

    void Start()
    {
        audioSource.time = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(-1.5f, transform.position.y);
            spriteRenderer.flipX = false;
            animator.SetTrigger("chop");
            audioSource.PlayOneShot(audioSource.clip);
            OnCutWood?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector2(1.5f, transform.position.y);
            spriteRenderer.flipX = true;
            animator.SetTrigger("chop");
            audioSource.PlayOneShot(audioSource.clip);
            OnCutWood?.Invoke();
        }
    }
    public static event Action OnCutWood;
}
