using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMGR : MonoBehaviour
{
    #region Fields
    
    [SerializeField]
    Canvas InfoScreenCVS;

    [SerializeField]
    Canvas MainMenuCVS;

    [SerializeField]
    Canvas PlayCVS;

    [SerializeField]
    Canvas SettingsCVS;

    [SerializeField]
    Canvas QuitConfirmationCVS;

    #endregion

    #region Methods

    void Start()
    {
        MainMenuCVS.gameObject.SetActive(true);
        InfoScreenCVS.gameObject.SetActive(false);
        PlayCVS.gameObject.SetActive(false);
        SettingsCVS.gameObject.SetActive(false);
        QuitConfirmationCVS.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !MainMenuCVS.gameObject.activeSelf)
        {
            BackToMain();
        }
    }

    public void PlayGame()
    {
        MainMenuCVS.gameObject.SetActive(false);
        PlayCVS.gameObject.SetActive(true);
    }

    public void CyberSecInfo()
    {
        InfoScreenCVS.gameObject.SetActive(true);
        MainMenuCVS.gameObject.SetActive(false);
    }

    public void Settings()
    {
        SettingsCVS.gameObject.SetActive(true);
        MainMenuCVS.gameObject.SetActive(false);
    }

    public void QuitConfirmation()
    {
        QuitConfirmationCVS.gameObject.SetActive(true);
        MainMenuCVS.gameObject.SetActive(false);
    }

    public void BackToMain()
    {
        MainMenuCVS.gameObject.SetActive(true);
        PlayCVS.gameObject.SetActive(false);
        InfoScreenCVS.gameObject.SetActive(false);
        SettingsCVS.gameObject.SetActive(false);
        QuitConfirmationCVS.gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit(0);
    }

    #endregion 
}
