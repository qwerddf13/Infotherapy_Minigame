using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FTime : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime = 60f; // 기본값을 60으로 설정

    void Update()
    {
        // 1. 시간이 0보다 클 때만 감소하도록 설정
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else
        {
            remainingTime = 0; // 0에서 멈추도록 고정
        }

        // 2. 남은 시간을 분과 초로 계산
        // Mathf.Max를 사용해 혹시 모를 음수 표시를 한 번 더 방지합니다.
        int minutes = Mathf.FloorToInt(Mathf.Max(remainingTime, 0) / 60);
        int seconds = Mathf.FloorToInt(Mathf.Max(remainingTime, 0) % 60);

        // 3. UI에 텍스트 표시
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}