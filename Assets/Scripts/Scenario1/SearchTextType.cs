// Author: Cybaware - Fatima

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchTextType : MonoBehaviour
{
    public string currentProductSearch;
    public Text searchText;
    public Button searchButton;

    void Start()
    {
        searchButton.interactable = false;
        searchText.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    /*  This function displays the searchbar text with a typing animation.
     */
    {
        yield return new WaitForSeconds(1);
        
        foreach (char letter in currentProductSearch)
        {
            searchText.text += letter;
            yield return new WaitForSeconds(0.1f); ; // waiting a single frame
        }

        searchButton.interactable = true;
    }
}
