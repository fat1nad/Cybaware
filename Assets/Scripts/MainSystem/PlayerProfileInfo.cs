using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProfileInfo : MonoBehaviour
{

    static string playerName;
    static int profileID;
    static int scenarioID; //Represents which scenario is being played right now. Updated in Load Scenari.

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

    public static int ScenarioID
    {
        get
        {
            return scenarioID;
        }
        set
        {
            // add constraints here/ 
            scenarioID = value;
        }
    }
}

