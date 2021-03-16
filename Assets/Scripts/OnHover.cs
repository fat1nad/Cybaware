using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnHover : MonoBehaviour
{
    public AudioSource audioSrc;
    public AudioClip hover;

    public void HoverSound()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        audioSrc.PlayOneShot(hover);
    }


}