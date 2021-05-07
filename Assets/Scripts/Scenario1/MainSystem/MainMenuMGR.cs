using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuMGR : MonoBehaviour
{
    #region Fields
    [SerializeField]
    Canvas StartCVS;

    [SerializeField]
    Canvas MainMenuCVS;

    [SerializeField]
    Canvas ScenarioCVS;

    [SerializeField]
    Canvas ProfileSelCVS;

    [SerializeField]
    Canvas InfoScreenCVS;

    [SerializeField]
    Canvas SettingsCVS;

    [SerializeField]
    Canvas QuitConfirmationCVS;

    [SerializeField]
    Canvas NewUserCVS;
     
    [SerializeField]
    Canvas ErrorCanvasProfileCreation;

    [SerializeField]
    Canvas ErrorCanvasProfileCreation2;

    [SerializeField]
    Canvas UserAddedPrompt;



    #endregion

    #region Methods
    private AudioSource audioSrc;
    public AudioClip hover;
    void Start()
    {
        ToStartScreen();
        audioSrc = GetComponent<AudioSource>();
        Debug.Log("Script: MainMenuMGR. Start() executed Successfully.");
    }
    
    // Update is called once per frame
    void Update()
    {
        if (StartCVS.gameObject.activeSelf)
        {//On Start Screen
            if (Input.anyKeyDown)
            {//if pressed escape, quit confirmation. else  go to main menu
                
                if (Input.GetKeyDown(KeyCode.Escape))
                    QuitConfirmation();
                
                else if (!MouseButtonsClicked())
                    ProfileSelection(); 
            }
        }
    }

    /// <summary>
    /// Function checks if any mouse button is pressed
    /// Referenced in the input region in the Update Function.
    /// </summary>
    /// <returns></returns>
    bool MouseButtonsClicked()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            return true;
        else if (Input.GetKeyDown(KeyCode.Mouse1))
            return true;
        else if (Input.GetKeyDown(KeyCode.Mouse2))
            return true;
        else if (Input.GetKeyDown(KeyCode.Mouse3))
            return true;
        else if (Input.GetKeyDown(KeyCode.Mouse4))
            return true;
        else if (Input.GetKeyDown(KeyCode.Mouse5))
            return true;
        else if (Input.GetKeyDown(KeyCode.Mouse6))
            return true;
        else
            return false;
    }

    public void ProfileSelection()
    { //Shows Players profiles 
        DisableAllCVS();
        ProfileSelCVS.gameObject.SetActive(true);
    }

    public void CyberSecInfo()
    {//Shows Cybersec demarcations
        DisableAllCVS();
        InfoScreenCVS.gameObject.SetActive(true);
    }

    public void Settings()
    {//Opens Settings menu
        DisableAllCVS();
        SettingsCVS.gameObject.SetActive(true);
    }

    public void QuitConfirmation()
    {//Confirm if quit
        DisableAllCVS();
        QuitConfirmationCVS.gameObject.SetActive(true);
    }

    public void Scenarios()
    {
        DisableAllCVS();
        ScenarioCVS.gameObject.SetActive(true);
    }

    public void ToMainMenu()
    {
        DisableAllCVS();
        MainMenuCVS.gameObject.SetActive(true);
    }

    public void ToStartScreen()
    {
        DisableAllCVS();
        StartCVS.gameObject.SetActive(true);
    }
    public void ToNewUserScreen()
    {
        DisableAllCVS();
        NewUserCVS.gameObject.SetActive(true);
    }


    private void DisableAllCVS()
    {
        MainMenuCVS.gameObject.SetActive(false);
        ScenarioCVS.gameObject.SetActive(false);
        StartCVS.gameObject.SetActive(false);
        ProfileSelCVS.gameObject.SetActive(false);
        InfoScreenCVS.gameObject.SetActive(false);
        SettingsCVS.gameObject.SetActive(false);
        QuitConfirmationCVS.gameObject.SetActive(false);
        NewUserCVS.gameObject.SetActive(false);
        ErrorCanvasProfileCreation.gameObject.SetActive(false);
        ErrorCanvasProfileCreation2.gameObject.SetActive(false);
        UserAddedPrompt.gameObject.SetActive(false);


    }

    public void Quit()
    {
        Application.Quit(0);
    }

    #endregion 
}