using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfileInfo : MonoBehaviour
{
    [SerializeField]
    string playerName;
    [SerializeField]
    int profileID;

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
