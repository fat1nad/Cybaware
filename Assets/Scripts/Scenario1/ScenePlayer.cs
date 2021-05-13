﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenePlayer : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Dialogue livingRoomSceneDialogue;
    public Dialogue bedroomSceneDialogue;
    public GameObject livingRoomScene;
    public GameObject bedroomScene;
    //public GameObject internetSurferButton;

    void Start()
    {
        StartCoroutine(PlayFirstScene());
    }

    IEnumerator PlayFirstScene()
    {
        bedroomScene.SetActive(false);

        yield return new WaitForSeconds(1);

        dialogueManager.StartDialogue(livingRoomSceneDialogue);

        while (dialogueManager.dialogueRunning)
        {
            yield return null;
        }

        bedroomScene.SetActive(true);
        bedroomScene.GetComponent<CanvasGroup>().interactable = false;
        bedroomScene.GetComponent<Animator>().SetTrigger("FadeInTrigger");

        yield return new WaitForSeconds(2);

        livingRoomScene.SetActive(false);

        dialogueManager.StartDialogue(bedroomSceneDialogue);

        while (dialogueManager.dialogueRunning)
        {
            yield return null;
        }

        bedroomScene.GetComponent<CanvasGroup>().interactable = true;

        //internetSurferButton.SetActive(true); //not part of first scene
        //anymore

        //SceneManager.LoadScene("EndLevel");
    }
}


