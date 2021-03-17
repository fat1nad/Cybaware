using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

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
    void Start()
    {

    }

    [SerializeField] 
    private PlayerData data;

    public void SaveIntoJson(string name, string Gib)
    {
        data = new PlayerData();
        data.playerName = name;
        data.Gibberish = Gib;
        Debug.Log(data.playerName);
        string playerdata = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/PlayerData.json", playerdata);
    }

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
        SaveIntoJson(userName, "aweinkuchbhi");
        
       


    }

    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
        public string Gibberish;
    }

}
