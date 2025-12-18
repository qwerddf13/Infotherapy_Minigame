using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;

public class Password : MonoBehaviour
{
    public string password = "000000";
    [SerializeField] TMP_InputField realText;
    [SerializeField] TMP_Text starText;

    [SerializeField] Button acceptButton;

    void Awake()
    {
        realText.text = "";
        starText.text = "";
        password = "000000";
    }

    void Update()
    {
        
    }

    public void WriteStarText()
    {
        starText.text = new string('*', realText.text.Length); 
    }

    public void CheckPassword()
    {
        if (realText.text == password)
        {
            acceptButton.interactable = true;
        }
        else
        {
            acceptButton.interactable = false;
        }
    }
}
