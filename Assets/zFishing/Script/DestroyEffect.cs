using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    [Header("삭제 시간 설정")]
    public float delay = 1.0f; // 1초 뒤에 삭제 (이펙트 길이에 맞춰 수정하세요)

    void Start()
    {
        // 지정된 시간(delay) 후에 이 오브젝트를 파괴합니다.
        Destroy(gameObject, 0.3f);
    }
}