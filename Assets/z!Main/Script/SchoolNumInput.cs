using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SchoolNumInput : MonoBehaviour
{    
    [SerializeField] TMP_InputField tMP_InputField;
    [SerializeField] Image image;
    [SerializeField] Button selectButton;
    [SerializeField] Button insertCoinButton;
    public static string schoolNum = "00000";

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
            schoolNum = tMP_InputField.text;

            selectButton.interactable = true;
            insertCoinButton.interactable = true;
        }
        else if (tMP_InputField.text.Length == 0)
        {
            image.color = new Color(1, 1, 1);
            schoolNum = "00000";

            selectButton.interactable = false;
            insertCoinButton.interactable = false;
        }
        else
        {
            image.color = new Color(1, 0, 0);
            schoolNum = "00000";

            selectButton.interactable = false;
            insertCoinButton.interactable = false;
        }
    }
}
