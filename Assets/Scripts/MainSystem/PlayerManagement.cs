using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManagement : MonoBehaviour
{
    [SerializeField]
    List<PlayerProfileButton> PlayerProfiles;

    Dictionary<int, string> cw_profiles;
    void Start()
    {
        // Loading players from database 
        if (!DatabaseConnection.db_connected)
            Debug.Log("Playermanagement.cs: Database not connected. Can't load profiles.");
        else
            LoadProfiles();
    }

    private void Update()
    {
        if (DatabaseConnection.db_updated["Profile"])
        {
            LoadProfiles();
            DatabaseConnection.db_updated["Profile"] = false;
        }
    }

    private void LoadProfiles()
    {
        cw_profiles = DatabaseConnection.LoadProfiles();

        int user = 0;

        foreach (int profileID in cw_profiles.Keys)
        {
            if (user < PlayerProfiles.Count)
            {
                PlayerProfiles[user].ProfileID = profileID;
                PlayerProfiles[user].PlayerName = cw_profiles[profileID];

                user += 1;
            }
        }
    }      
}