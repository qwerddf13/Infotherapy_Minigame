using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashObject : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Material flashMaterial;
    Material originMaterial;

    void Start()
    {
        originMaterial = spriteRenderer.material;
    }

    void Update()
    {

    }
    // 플래시하는 코루틴 함수 만들기 (가능하다면 보편적 실행 방법 찾기)
}
