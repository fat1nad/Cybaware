using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Fungus;
public class Scenario2Manager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI location;

    [SerializeField]
    List<Sprite> backgrounds;

    string playerName;
    int profileID;

    [SerializeField]
    Character mainPlayer;

    // Start is called before the first frame update
    void Start()
    {
        playerName = PlayerProfileInfo.PlayerName;
        profileID = PlayerProfileInfo.ProfileID;
        location.text = "Airport";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
