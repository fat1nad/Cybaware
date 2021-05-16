using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mono.Data.Sqlite;

public class CreateUser : MonoBehaviour
{
    [SerializeField]
    TMP_InputField newPlayerName;
    int maxProfileCount = 5;

    
    public PlayerProfileButton NewPlayer; 

    public void CreateProfile()
    {
        Dictionary<int, string> cw_profiles = DatabaseConnection.LoadProfiles();

        if (cw_profiles.Count < maxProfileCount)
        {
            if (newPlayerName.text == "")
            {
                Debug.LogError("Error: New Player name cant be empty string.");
            }
            else
            {


                string insert = "INSERT INTO Profile (PlayerName) ";
                string vals = "VALUES (\"" + "" + newPlayerName.text + "\");";

                /// Fix this to prevent SQL injection attack later.
                IDbCommand dbcmd = DatabaseConnection.CWdatabase.CreateCommand();
                dbcmd.CommandText = insert + vals;

                // Inserting into the Database 
                dbcmd.ExecuteNonQuery();

                //Raise a flag to show Profile table was updated.
                DatabaseConnection.db_updated["Profile"] = true;

                //Fetch the ProfileID of the newly inserted Player 
                string table = "FROM Profile ";
                string select = "SELECT ProfileID ";
                string condition = "WHERE PlayerName = \"" + newPlayerName.text + "\";";

                dbcmd.Dispose();
                dbcmd = DatabaseConnection.CWdatabase.CreateCommand();
                dbcmd.CommandText = select + table + condition;

                IDataReader reader = dbcmd.ExecuteReader();
                reader.Read();

                NewPlayer.PlayerName = newPlayerName.text;
                NewPlayer.ProfileID = reader.GetInt32(0);

                reader.Close();
                reader = null;

                Debug.Log(NewPlayer.ProfileID.ToString() + " : " + NewPlayer.PlayerName);

                insert = "INSERT INTO ProfilePreferences (ProfileID) ";
                vals = "VALUES (" + NewPlayer.ProfileID.ToString() + ");";

                /// Fix this to prevent SQL injection attack later.
                dbcmd.Dispose();
                dbcmd = DatabaseConnection.CWdatabase.CreateCommand();
                dbcmd.CommandText = insert + vals;

                // Inserting into the Database 
                dbcmd.ExecuteNonQuery();

                //Raise a flag to show ProfilePreferences table was updated.
                DatabaseConnection.db_updated["ProfilePreferences"] = true;

                dbcmd.Dispose();
                dbcmd = null;
                NewPlayer = null;
            }
        }
    }
}
