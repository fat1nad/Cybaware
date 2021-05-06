using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrowserFunctions : MonoBehaviour
{
    public GameObject WebAddress;
    public GameObject PromptExtraSofa;
    public GameObject TickConfirmation;
    public GameObject SofLandWebsite;
    public GameObject MailWebsite;

    // Start is called before the first frame update
    private static bool addToCart = false;
    public void SetTickConfirmActive()
    {
        Debug.Log(TickConfirmation.activeSelf.ToString());
        
        if(TickConfirmation.activeSelf == false)
        {
            
            if (addToCart == true)
            {
                this.gameObject.tag = "Selected";
                TickConfirmation.SetActive(true);
            }

            
            
        }
        else
        {
            this.gameObject.tag = "Unselected";
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

    private void OpenReview()
    {

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

