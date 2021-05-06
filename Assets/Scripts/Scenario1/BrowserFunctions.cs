using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrowserFunctions : MonoBehaviour
{
    public GameObject TickConfirmation;
    // Start is called before the first frame update
    public void SetTickConfirmActive()
    {
        Debug.Log(TickConfirmation.activeSelf.ToString());
        if(TickConfirmation.activeSelf == false)
        {
            this.gameObject.tag = "Selected";
            TickConfirmation.SetActive(true);
            
        }
       
        else
        {
            this.gameObject.tag = "Unselected";
            TickConfirmation.SetActive(false);
        }

        
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

