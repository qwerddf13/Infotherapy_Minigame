using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Gogi") || collision.name == "Clone_Gogi")
        {
            if (Input.GetMouseButtonUp(0))
            {
                Gogi gogiScript = collision.GetComponent<Gogi>();
                if (gogiScript != null)
                {
                    // 점수 고기 상태에 따라 다르게
                    int getScore = gogiScript.GetScore();

                   
                    Score.instance.AddScore(getScore);

                    // 점수얻고 고기 삭제
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}