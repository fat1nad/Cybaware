using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopInteractionManager : MonoBehaviour
{
    public GameObject internetSurfer;
    public GameObject internetSurferButton;

    public void OpenInternetSurfer()
    {
        internetSurfer.SetActive(true);
        internetSurfer.GetComponent<Animator>().SetTrigger("openInternetSurfer");
        internetSurferButton.SetActive(false);
    }
}
