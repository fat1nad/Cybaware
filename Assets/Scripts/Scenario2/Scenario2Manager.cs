using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Fungus;
using UnityEngine.SceneManagement;


public class Scenario2Manager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI location;

    [SerializeField]
    List<Sprite> backgrounds;

    string playerName;
    int profileID;

    [SerializeField]
    Canvas PauseCanvas;

    // Start is called before the first frame update
    void Start()
    {
        playerName = PlayerProfileInfo.PlayerName;
        profileID = PlayerProfileInfo.ProfileID;
        PlayerProfileInfo.ScenarioID = 2;

        location.text = "Airport";

        PauseCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        if (PauseCanvas.gameObject.activeSelf)
        {
            Time.timeScale = 1.0f;
            PauseCanvas.gameObject.SetActive(false);
        }

        else if (!PauseCanvas.gameObject.activeSelf)
        {
            Time.timeScale = 0.0f;
            PauseCanvas.gameObject.SetActive(true);
        }
    }

    public void QuitScenario()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
