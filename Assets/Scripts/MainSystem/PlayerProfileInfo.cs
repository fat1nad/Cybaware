using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProfileInfo : MonoBehaviour
{

    static string playerName;
    static int profileID;

    [SerializeField]
    TextMeshProUGUI displayName;

    private void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Update()
    {
        if (displayName.text != playerName)
        {
            displayName.text = playerName;
        }
    }


    public static string PlayerName 
    {
        get
        {
            return playerName;
        }
        set
        {
            if (value!= "")
                playerName = value;
            else
                Debug.LogError("Error: Name can't be empty string.");
        }
    }

    public static int ProfileID
    {
        get
        {
            return profileID;
        }
        set
        {
            if (value != 0)
                profileID = value;
            else
                Debug.LogError("Error: Can not set profileID = 0.");
        }
    }

}
