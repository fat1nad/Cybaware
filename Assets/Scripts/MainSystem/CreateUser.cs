using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;

using System.Runtime.Serialization.Formatters.Binary;
public class CreateUser : MonoBehaviour
{
    [SerializeField]
    Canvas ErrorCanvasProfileCreation;

    [SerializeField]
    Canvas ErrorCanvasProfileCreation2;

    [SerializeField]
    Canvas UserAddedPrompt;

    [SerializeField]
    public List<Players> players = new List<Players>();

    public GameObject Player1_inactive;
    public GameObject Player2_inactive;
    public GameObject Player3_inactive;
    public GameObject Player4_inactive;
    public GameObject Player5_inactive;
    public Button Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    public GameObject Player5;


    private List<string> userNames = new List<string>();
    
    // Start is called before the first frame update
    public TMP_InputField IPField;
    private string userName;
    void Start()
    {
        string path = Application.persistentDataPath + "/UserProfiles.fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            players = formatter.Deserialize(stream) as List<Players>;
            stream.Close();
            for (int i = 0; i < players.Count; i++)
            {
                if(i==0)
                {
                    Debug.Log("Tryin to changee");
                    Player1.gameObject.SetActive(true);
                    Player1.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = players[i].playerName;
                    
                    Player1_inactive.gameObject.SetActive(false);
                }
                if (i==1)
                {
                    Player2.gameObject.SetActive(true);
                    Player2.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = players[i].playerName;

                    Player2_inactive.gameObject.SetActive(false);
                }
                if (i == 2)
                {
                    Player3.gameObject.SetActive(true);
                    Player3.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = players[i].playerName;

                    Player3_inactive.gameObject.SetActive(false);
                }
                if (i == 3)
                {
                    Player4.gameObject.SetActive(true);
                    Player4.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = players[i].playerName;

                    Player4_inactive.gameObject.SetActive(false);
                }
                if (i == 4)
                {
                    Player5.gameObject.SetActive(true);
                    Player5.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = players[i].playerName;

                    Player5_inactive.gameObject.SetActive(false);
                }


            }
            Debug.Log(players[0].playerName);
            Debug.Log(players[1].playerName);


        }

    }

    [SerializeField] 
    private SaveData data;

    public void SavePlayer(string name, string Gib)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/UserProfiles.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        Players playerData = new Players();
        playerData.Gibberish = Gib;
        playerData.playerName = name;
        players.Add(playerData);

        formatter.Serialize(stream, players);
        stream.Close();
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
        SavePlayer(userName, "aweinkuchbhi");
        
       


    }

    [System.Serializable]
    public class Players
    {
        public string playerName;
        public string Gibberish;
    }


}
