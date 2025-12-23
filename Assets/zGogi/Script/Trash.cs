using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private GameObject gogiInTrash = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gogi"))
        {
            gogiInTrash = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Gogi"))
        {
            gogiInTrash = null;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && gogiInTrash != null)
        {
            Destroy(gogiInTrash);
            gogiInTrash = null;
        }
    }
}