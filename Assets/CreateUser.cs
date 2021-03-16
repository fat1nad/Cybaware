using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CreateUser : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField IPField;
    void Start()
    {

        IPField = GameObject.Find("InputField").GetComponent < "TMP_InputField" > ();
    }
    public void Create()
    {
        string username = "bla";
        username = IPField.text;
        Debug.Log(username);
    }
}
