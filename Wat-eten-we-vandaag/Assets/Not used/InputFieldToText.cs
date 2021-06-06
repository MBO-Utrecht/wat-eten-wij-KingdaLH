using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputFieldToText : MonoBehaviour
{
    public TMP_InputField Field;
    public TMP_Text TextBox;
 
    public void CopyText() 
    {
        TextBox.text = Field.text;
    }
}
