using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using UnityEngine;



public class DatabaseConnection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string connection_string = "URI=file:" + Application.dataPath + "/CWDB.db"; //Path to database.
        
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(connection_string);
        
        dbconn.Open(); //Open connection to the database.
        
        IDbCommand dbcmd = dbconn.CreateCommand();
        
        string sqlQuery = "SELECT ProfileID, PlayerName " + "FROM Profile";
        
        dbcmd.CommandText = sqlQuery;
        
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int pID = reader.GetInt32(0);
            string name = reader.GetString(1);
                
            Debug.Log("ProfileID= " + pID+ "  name =" + name);
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}