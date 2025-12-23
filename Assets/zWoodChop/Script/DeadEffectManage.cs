using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEffectManage : MonoBehaviour
{
    public GameObject deadEffect;
    public Animator deadEffectAnimator;
    public Animator playerAnimator;
    public AudioSource woodCrashSound;
    public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnEnable()
    {
        GameManage.OnGameOver += DoCoroutine;
    }

    void OnDisable()
    {
        GameManage.OnGameOver -= DoCoroutine;
    }

    void DoCoroutine()
    {
        StartCoroutine(DoShowDeadEffect());
    }

    IEnumerator DoShowDeadEffect()
    {
        deadEffect.SetActive(true);
        transform.position = player.transform.position;

        yield return new WaitUntil(() => playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Dead"));
        yield return new WaitUntil(() => playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.60f);
        woodCrashSound.volume = 1;
        woodCrashSound.PlayOneShot(woodCrashSound.clip);
        // 게이지 아웃 오버도 만들기
        
        yield return new WaitUntil(() => deadEffectAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
        deadEffect.SetActive(false);
    }
}
