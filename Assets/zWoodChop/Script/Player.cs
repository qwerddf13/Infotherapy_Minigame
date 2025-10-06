using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public AudioSource audioSource;
    public SpawnWood spawnWood;
    bool isGameRunning = true;

    void Start()
    {
        audioSource.time = 0.1f;
        isGameRunning = true;
    }

    void Update()
    {
        if (isGameRunning == true) {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(-1.5f, transform.position.y);
            spriteRenderer.flipX = false;
            animator.SetTrigger("chop");
            audioSource.PlayOneShot(audioSource.clip);
            OnCutWood?.Invoke();

            if (spawnWood.woodNums[0] == 2)
            {
                OnOver_Player?.Invoke();
                Debug.Log("플레이어 게임 오버.");
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector2(1.5f, transform.position.y);
            spriteRenderer.flipX = true;
            animator.SetTrigger("chop");
            audioSource.PlayOneShot(audioSource.clip);
            OnCutWood?.Invoke();

            if (spawnWood.woodNums[0] == 3)
            {
                OnOver_Player?.Invoke();
                Debug.Log("플레이어 게임 오버.");
            }
        }
        }
    }
    public static event Action OnCutWood;
    public static event Action OnOver_Player;

    void OnEnable()
    {
        GameManage.OnGameOver += GameOver;
    }

    void OnDisable()
    {
        GameManage.OnGameOver -= GameOver;
    }

    void GameOver()
    {
        spriteRenderer.flipY = true;
        isGameRunning = false;
    }
}
