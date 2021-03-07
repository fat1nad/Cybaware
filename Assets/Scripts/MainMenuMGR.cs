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



    #endregion

    #region Methods
    private AudioSource audio;
    public AudioClip hover;
    void Start()
    {

            ToStartScreen();
            audio = GetComponent<AudioSource>();
            Debug.Log("sdfd");


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
                else if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Mouse2) || Input.GetKeyDown(KeyCode.Mouse3))
                {
                    Debug.Log("MousebuttonsClicked");
                }
                else
                {
                    ProfileSelection();
                }
                    
            }
        }
    }
    void MouseEnter()
    {
        Debug.Log("aly audioo");
        audio.PlayOneShot(hover);
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

    private void DisableAllCVS()
    {
        MainMenuCVS.gameObject.SetActive(false);
        ScenarioCVS.gameObject.SetActive(false);
        StartCVS.gameObject.SetActive(false);
        ProfileSelCVS.gameObject.SetActive(false);
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