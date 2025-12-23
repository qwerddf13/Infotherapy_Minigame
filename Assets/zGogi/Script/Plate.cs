using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private GameObject gogiInPlate = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Gogi"))
        {
            gogiInPlate = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Gogi"))
        {
            gogiInPlate = null;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && gogiInPlate != null)
        {
            Gogi gogiScript = gogiInPlate.GetComponent<Gogi>();
            if (gogiScript != null)
            {
                int getScore = gogiScript.GetScore();

                if (Score.instance != null)
                {
                    Score.instance.AddScore(getScore);
                    Debug.Log("���� ȹ��: " + getScore);
                }


                Destroy(gogiInPlate);
                gogiInPlate = null;
            }
        }
    }
}
