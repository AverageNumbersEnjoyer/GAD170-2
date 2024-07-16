using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoTextBox : MonoBehaviour
{
    //Create Variables
    public TextMeshProUGUI tmpGUI;

    public void UpdateText(string _text)
    {
        if (_text != null)
        {
            tmpGUI.text = _text;
        }
    }


    
}
