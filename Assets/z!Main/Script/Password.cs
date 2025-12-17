using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;

public class Password : MonoBehaviour
{
    string password = "000000";
    [SerializeField] TMP_InputField realText;
    [SerializeField] TMP_Text starText;
    [SerializeField] TMP_Text placeHolder;

    void Awake()
    {
        realText.text = "";
        starText.text = "";
    }

    void Update()
    {
        
    }

    public void WriteStarText()
    {
        starText.text = new string('*', realText.text.Length); 
    }
}
