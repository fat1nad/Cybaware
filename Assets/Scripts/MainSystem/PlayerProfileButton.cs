using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProfileButton : MonoBehaviour
{
    int profileID;
    string playerName;
    bool newUser;

    [SerializeField]
    TextMeshProUGUI nameText;

    [SerializeField]
    Canvas newPlayerCanvas;

    [SerializeField]
    PlayerProfileInfo currentPlayerInfo;

    private void Awake()
    {
        newUser = true;
        newPlayerCanvas.gameObject.SetActive(false);
        
        playerName = "New User";
        profileID = 0; //Profile ID will never be 0
        nameText.text = playerName;
    }

    private void Update()
    {
        if (playerName != "New User" && profileID != 0)
        {
            newUser = false;
        }

        if (nameText.text != playerName)
        {
            nameText.text = playerName;
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
            if (newUser)
            {
                playerName = value;
            }
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
            if (newUser)
            {
                profileID = value;
            }
        }
    }

    public bool NewUser()
    {
        return newUser;
    }
    
    public void AddUser()
    {
        //Called when new profile button pressed 
        if (newUser)
        {
            newPlayerCanvas.GetComponent<CreateUser>().NewPlayer = this;
            newPlayerCanvas.gameObject.SetActive(true);
        }
    }

    public void UserSelected()
    {
        PlayerProfileInfo.PlayerName = playerName;
        PlayerProfileInfo.ProfileID = profileID;
    }

}
