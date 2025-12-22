using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gogi : MonoBehaviour
{
    public Sprite frontGogi, backGogi, roastfrontGogi, roastbackGogi;
    public Sprite burnGogi;



    // 굽기 상태
    public bool isFront = true;
    public float frontTime = 0f, backTime = 0f;
    public bool isOnGrill = false;

    // 굽기 시간
    private SpriteRenderer sr;
    private const float cook_time = 3f;
    private const float burn_time = 5f;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        ResetGogi();
    }




    public void ResetGogi()
    {
        frontTime = 0f;
        backTime = 0f;
        isFront = true;
        isOnGrill = false;
        if (sr != null && frontGogi != null) sr.sprite = frontGogi;
    }

    public void Flip() { isFront = !isFront; Visual(); }

    void Update()
    {
        if (isOnGrill)
        {
            if (isFront) backTime += Time.deltaTime;
            else frontTime += Time.deltaTime;
            Visual();
        }
    }


    public int GetScore()
    {
        float bestTime = Mathf.Max(frontTime, backTime);

        if (bestTime >= burn_time) return -1; // 타면 감점
        if (bestTime >= cook_time) return 10; // 익으면 득점
        return 1; // 생고기는 조금
    }



    void Visual()
    {
        if (sr == null) return;

        float currentTime = isFront ? frontTime : backTime;
        Sprite normalSprite = isFront ? frontGogi : backGogi;
        Sprite roastedSprite = isFront ? roastfrontGogi : roastbackGogi;

        if (currentTime >= burn_time) // 탄 상태
        {
            sr.sprite = burnGogi;
        }
        else if (currentTime >= cook_time) // 익은 상태
        {
            sr.sprite = roastedSprite;
        }
        else // 생고기
        {
            sr.sprite = normalSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) { if (collision.CompareTag("Grill")) isOnGrill = true; }
    private void OnTriggerExit2D(Collider2D collision) { if (collision.CompareTag("Grill")) isOnGrill = false; }
}