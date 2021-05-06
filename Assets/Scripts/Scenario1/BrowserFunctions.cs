using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrowserFunctions : MonoBehaviour
{
    public GameObject TickConfirmation;
    public Sofa Selected;
    // Start is called before the first frame update
    public void SetTickConfirmActive()
    {
        Debug.Log(TickConfirmation.activeSelf.ToString());
        if(TickConfirmation.activeSelf == false)
        {
            TickConfirmation.SetActive(true);
            Selected.SelectedSofa= this.gameObject;
            
        }
       
        else
        {
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

