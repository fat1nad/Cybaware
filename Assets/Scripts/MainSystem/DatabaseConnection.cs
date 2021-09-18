using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using UnityEngine;



public class DatabaseConnection : MonoBehaviour
{
    #region Fields

    public static IDbConnection CWdatabase;
    public static bool db_connected;
    public static List<string> db_table_names;
    public static Dictionary<string, bool> db_updated;

    #endregion

    #region Methods


    /// <summary>
    /// 1. Awake -> Connect to database 
    /// 2. database connection made static 
    /// 3. load profile data
    /// </summary>
    private void Awake()
    {
        Debug.Log(Application.persistentDataPath);
        Debug.Log(Application.dataPath);

        db_connected = Connect();
        
        db_table_names = new List<string>();
        db_table_names.Add("Profile");
        db_table_names.Add("ProfilePreferences");
        db_table_names.Add("Savefile");
        db_table_names.Add("Scenario");
        db_table_names.Add("Events");
        db_table_names.Add("LearningOutcomes");
        db_table_names.Add("PlayerOutcomeAssessment");


        db_updated = new Dictionary<string, bool>();
        foreach (string item in db_table_names)
            db_updated.Add(item, false);

    }

    static bool Connect()
    {
        string connection_string = "URI=file:" + Application.dataPath + "/StreamingAssets/CWDB.db"; //Path to database.

        CWdatabase = (IDbConnection)new SqliteConnection(connection_string);
        CWdatabase.Open(); //Open connection to the database.

        if (CWdatabase.State != ConnectionState.Open)
        {
            return false;
        }
        return true;
    }

    public static Dictionary<int, string> LoadProfiles()
    {
        string table = "FROM Profile";
        string select = "SELECT ProfileID, PlayerName ";

        IDbCommand dbcmd = CWdatabase.CreateCommand();
        dbcmd.CommandText = select + table;

        if (db_connected)
        {
            IDataReader reader = dbcmd.ExecuteReader();

            Dictionary<int, string> cw_profiles = new Dictionary<int, string>();

            while (reader.Read())
            {
                cw_profiles.Add(reader.GetInt32(0), reader.GetString(1));
            }

            reader.Close();
            reader = null;

            dbcmd.Dispose();
            dbcmd = null;

            return cw_profiles;
        }

        return null;
        
    }

    static void DisconnectDB()
    {
        CWdatabase.Close();
        CWdatabase = null;
    }

    private void OnApplicationQuit()
    {
        DisconnectDB();
    }

    #endregion
}