using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEffectManage : MonoBehaviour
{
    public GameObject deadEffect;
    public Animator deadEffectAnimator;
    public Animator playerAnimator;
    public AudioSource woodCrashSound;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnEnable()
    {
        GameManage.OnGameOver += () => StartCoroutine(DoShowDeadEffect());
    }

    void OnDisable()
    {

    }

    IEnumerator DoShowDeadEffect()
    {
        deadEffect.SetActive(true);

        yield return new WaitUntil(() => playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Dead"));
        yield return new WaitUntil(() => playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.60f);
        woodCrashSound.volume = 1;
        woodCrashSound.PlayOneShot(woodCrashSound.clip);
        // 게이지 아웃 오버도 만들기
        
        yield return new WaitUntil(() => deadEffectAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
        deadEffect.SetActive(false);
    }
}
