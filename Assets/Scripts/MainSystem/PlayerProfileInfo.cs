using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProfileInfo : MonoBehaviour
{
    string playerName;
    int profileID;

    [SerializeField]
    TextMeshProUGUI displayName;

    private void Update()
    {
        if (displayName.text != playerName)
        {
            displayName.text = playerName;
        }
    }


    public string PlayerName 
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

    public int ProfileID
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
