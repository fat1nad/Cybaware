using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BrowserFunctions : MonoBehaviour
{
    public GameObject ReviewScreen;
    public GameObject ReviewScreenSofa;
    public GameObject WebAddress;
    public GameObject PromptExtraSofa;
    public GameObject TickConfirmation;
    public GameObject SofLandWebsite;
    public GameObject MailWebsite;

    // Start is called before the first frame update
   // private static bool addToCart = false;
    public void SetTickConfirmActive()
    {
        Debug.Log(TickConfirmation.activeSelf.ToString());
        
        if(TickConfirmation.activeSelf == false)
        {
           
            this.gameObject.tag = "Selected";
            GameObject[] SelectedObjs;
            SelectedObjs = GameObject.FindGameObjectsWithTag("Selected");
            ReviewScreenSofa.GetComponentInChildren<Image>().sprite = SelectedObjs[0].GetComponent<Image>().sprite;
            ReviewScreenSofa.transform.Find("Name").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = SelectedObjs[0].transform.Find("Name").GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            ReviewScreenSofa.transform.Find("Price").GetComponentInChildren<TMPro.TextMeshProUGUI>().text = SelectedObjs[0].transform.Find("Price").GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            ReviewScreen.gameObject.SetActive(true);




        }
        else
        {
            TickConfirmation.SetActive(false);
            
        }

    }
    public void SwitchToMail()
    {
        SofLandWebsite.gameObject.SetActive(false);
        MailWebsite.gameObject.SetActive(true);
        WebAddress.GetComponent<TMPro.TextMeshProUGUI>().text = "www.mail.com";

    }
    public void SwitchToSofLand()
    {
        SofLandWebsite.gameObject.SetActive(true);
        MailWebsite.gameObject.SetActive(false);
        WebAddress.GetComponent<TMPro.TextMeshProUGUI>().text = "www.sofLand.com";


    }

    public void AddToCart()
    {
        GameObject[] SelectedObjs;
        SelectedObjs = GameObject.FindGameObjectsWithTag("Selected");
        SelectedObjs[0].transform.Find("TickConfirm").gameObject.SetActive(true);
       
        

    }
    public void CancelAddtoCart()
    {
        GameObject[] SelectedObjs;
        SelectedObjs = GameObject.FindGameObjectsWithTag("Selected");
        SelectedObjs[0].tag = "Unselected";
        ReviewScreen.gameObject.SetActive(false);
    }
    public void GoToCart()
    {
         GameObject[] SelectedObjs;
         SelectedObjs = GameObject.FindGameObjectsWithTag("Selected");
        if (SelectedObjs.Length > 1)
        {
            PromptExtraSofa.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Only One Sofa selected");
        }




    }
    public void ClosePromptSofa()
    {
        this.gameObject.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
public class Sofa
{
    public GameObject SelectedSofa;
}

