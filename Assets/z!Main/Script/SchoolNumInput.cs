using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SchoolNumInput : MonoBehaviour
{    
    [SerializeField] TMP_InputField tMP_InputField;
    [SerializeField] Image image;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CheckNumFilled()
    {
        if (tMP_InputField.text.Length == 5)
        {
            image.color = new Color(0, 1, 0);
        }
        else if (tMP_InputField.text.Length == 0)
        {
            image.color = new Color(1, 1, 1);
        }
        else
        {
            image.color = new Color(1, 0, 0);
        }
    }
}
