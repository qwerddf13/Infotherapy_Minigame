using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public SpawnWood spawnWood;
    public ScreenShake screenShake;
    public GameManage gameManage;
    public Leaderboards leaderboards;
    public ScoreManage scoreManage;

    void Start()
    {
        StartCoroutine(DoGameStart());
    }

    void Update()
    {
        if (gameManage.isGameRunning == true) {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(-1.5f, transform.position.y);
            spriteRenderer.flipX = false;
            
            animator.SetTrigger("chop");

            screenShake.ShakeForTime(0.02f);

            OnCutWood?.Invoke(false);

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
            
            screenShake.ShakeForTime(0.02f);

            OnCutWood?.Invoke(true);

            if (spawnWood.woodNums[0] == 3)
            {
                OnOver_Player?.Invoke();
                Debug.Log("플레이어 게임 오버.");
            }
        }
        }
    }
    public static event Action<bool> OnCutWood;
    public static event Action OnOver_Player;

    void OnEnable()
    {
        GameManage.OnGameOver += GameOver;
    }

    void OnDisable()
    {
        GameManage.OnGameOver -= GameOver;
    }

    IEnumerator DoGameStart()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow));

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(-1.5f, transform.position.y);
            spriteRenderer.flipX = false;
            
            animator.SetTrigger("chop");

            screenShake.ShakeForTime(0.02f);

            OnCutWood?.Invoke(false);

            if (spawnWood.woodNums[0] == 2)
            {
                OnOver_Player?.Invoke();
                //animator.SetTrigger("dead");
                Debug.Log("플레이어 게임 오버.");
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector2(1.5f, transform.position.y);
            spriteRenderer.flipX = true;
            
            animator.SetTrigger("chop");
            
            screenShake.ShakeForTime(0.02f);

            OnCutWood?.Invoke(true);

            if (spawnWood.woodNums[0] == 3)
            {
                OnOver_Player?.Invoke();
                //animator.SetTrigger("dead");
                Debug.Log("플레이어 게임 오버.");
            }
        }

        gameManage.isGameRunning = true;

        yield break;
    }

    void GameOver()
    {
        animator.SetTrigger("dead");
        leaderboards.SubmitScore("CuttingWoods", "kimmm", scoreManage.score);
        gameManage.isGameRunning = false;
    }
}
