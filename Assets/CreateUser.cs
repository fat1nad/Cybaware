using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CreateUser : MonoBehaviour
{
    [SerializeField]
    Canvas ErrorCanvasProfileCreation;

    [SerializeField]
    Canvas ErrorCanvasProfileCreation2;

    [SerializeField]
    Canvas UserAddedPrompt;

    private List<string> userNames = new List<string>();
    
    // Start is called before the first frame update
    public TMP_InputField IPField;
    private string userName;
    public void Create()
    {
        userNames.Add("Jeff");
        userNames.Add("Bruce");
        userNames.Add("Nancy");

        userName = "bla";
        userName = IPField.GetComponent<TMP_InputField>().text;
        if(userName == "")
        {
            ErrorCanvasProfileCreation.gameObject.SetActive(true);
            return;
            

        }
        foreach (string user in userNames)
        {
            if(user == userName)
            {
                ErrorCanvasProfileCreation2.gameObject.SetActive(true);
                return;
               
                
            }
        }
        Debug.Log(userName);
        UserAddedPrompt.gameObject.SetActive(true);


    }
}
