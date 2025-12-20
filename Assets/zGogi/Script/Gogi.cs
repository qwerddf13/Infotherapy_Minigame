using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gogi : MonoBehaviour
{
    [Header("이미지 설정")]
    public Sprite frontGogi;
    public Sprite backGogi;
    public Sprite roastfrontGogi;
    public Sprite roastbackGogi;

    [Header("굽기 상태")]
    public bool isFront = true; // 현재 앞면
    public float frontTime = 0f; // 앞면 구워진 시간
    public float backTime = 0f; // 뒷면 구워진 시간
    public bool isOnGrill = false; // 불판 위에 있나 확인

    private SpriteRenderer sr;
    private const float cook_time = 3f; // 익는데 걸리는 시간

    void Awake() => sr = GetComponent<SpriteRenderer>();

    public void Flip()
    {
        isFront = !isFront;
        Visual();
    }

    void Update() // 고기 구워지는 시간 + 구운 이미지로 바뀌는거
    {
        if (isOnGrill)
        {
            if (isFront)
            {
                backTime += Time.deltaTime;
            }
            else
            {
                frontTime += Time.deltaTime;
            }

            Visual();
        }
    }

    void Visual()
    {
        if (isFront)
        {
            sr.sprite = (frontTime >= cook_time) ? roastfrontGogi : frontGogi;
        }
        else
        {
            sr.sprite = (backTime >= cook_time) ? roastbackGogi : backGogi;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Grill")) isOnGrill = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Grill")) isOnGrill = false;
    }
}
