using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    [SerializeField] private PlayerData data = new PlayerData();

    public void SaveIntoJson()
    {
        string playerdata = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/PlayerData.json", playerdata);
    }
}

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public string Gibberish;
}


