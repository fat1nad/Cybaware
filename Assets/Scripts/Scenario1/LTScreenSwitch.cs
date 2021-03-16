using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTScreenSwitch : MonoBehaviour
{
    [SerializeField]
    GameObject normalBrowser;

    [SerializeField]
    GameObject comfortWorldPage;

    [SerializeField]
    GameObject sweetDreamsPage;
    GameObject loginWindow;
    GameObject advertise;
    GameObject mainItem;
    GameObject report;

    private void Start()
    {
        loginWindow = sweetDreamsPage.transform.GetChild(2).gameObject;
        advertise = sweetDreamsPage.transform.GetChild(3).gameObject;
        mainItem = sweetDreamsPage.transform.GetChild(4).gameObject;
        report = sweetDreamsPage.transform.GetChild(5).gameObject;

        normalBrowser.SetActive(true);
        comfortWorldPage.SetActive(false);
        sweetDreamsPage.SetActive(false);
    }

    public void BackToSearch()
    {
        //Setup normal browser page
        normalBrowser.SetActive(true);
        normalBrowser.transform.GetChild(0).gameObject.SetActive(false);
        normalBrowser.transform.GetChild(1).gameObject.SetActive(true);

        //Setup Comfortworld page
        comfortWorldPage.transform.GetChild(0).gameObject.SetActive(true);
        comfortWorldPage.transform.GetChild(1).gameObject.SetActive(false);
        comfortWorldPage.transform.GetChild(3).gameObject.SetActive(false);
        comfortWorldPage.SetActive(false);
        
        //Setup SweetDreamsPage
        loginWindow.SetActive(true);
        mainItem.SetActive(false);
        advertise.SetActive(false);
        sweetDreamsPage.SetActive(false);
        report.transform.GetChild(2).gameObject.SetActive(false);
        report.transform.GetChild(3).gameObject.SetActive(false);
        report.SetActive(false);

    }

    public void Login()
    {
        loginWindow.SetActive(false);
        advertise.SetActive(true);
        mainItem.SetActive(true);
    }

    public void Purchase()
    {
        advertise.SetActive(false);
        mainItem.SetActive(false);
        report.SetActive(true);
        report.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void Scammed()
    {
        advertise.SetActive(false);
        mainItem.SetActive(false);
        report.SetActive(true);
        report.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void InsecureScame ()
    {
        comfortWorldPage.transform.GetChild(0).gameObject.SetActive(false);
        comfortWorldPage.transform.GetChild(1).gameObject.SetActive(false);
        comfortWorldPage.transform.GetChild(3).gameObject.SetActive(true);
    }
}
