using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private GameObject gogiInPlate = null; // 그릇 위에 올라와 있는 고기

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 고기가 그릇 범위 안으로 들어오면 기억함
        if (collision.CompareTag("Gogi"))
        {
            gogiInPlate = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 고기가 그릇 밖으로 나가면 잊어버림
        if (collision.CompareTag("Gogi"))
        {
            gogiInPlate = null;
        }
    }

    void Update()
    {
        // 마우스를 뗐을 때, 그릇 위에 고기가 있다면 점수 처리
        if (Input.GetMouseButtonUp(0) && gogiInPlate != null)
        {
            Gogi gogiScript = gogiInPlate.GetComponent<Gogi>();
            if (gogiScript != null)
            {
                int getScore = gogiScript.GetScore();

                // Score 스크립트 호출
                if (Score.instance != null)
                {
                    Score.instance.AddScore(getScore);
                    Debug.Log("점수 획득: " + getScore);
                }

                // 점수 얻고 고기 즉시 삭제
                Destroy(gogiInPlate);
                gogiInPlate = null; // 참조 비우기
            }
        }
    }
}