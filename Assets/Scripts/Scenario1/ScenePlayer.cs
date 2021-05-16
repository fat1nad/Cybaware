// Author: Cybaware - Fatima

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class ScenePlayer : MonoBehaviour
/* This class is used to play cutscenes for Scenario 1.
 */
{
    // all objects required for First Cutscene 
    public DialogueManager dialogueManager;
    public Dialogue livingRoomSceneDialogue;
    public Dialogue bedroomSceneDialogue;
    public GameObject livingRoomScene;
    public GameObject bedroomScene;

    // all objects required for Second Cutscene
    public Dialogue endSecondSceneDialogue;
    public CanvasGroup browserCanvasGroup;

    private bool secondCutscenePlayed;

    void Start()
    {
        secondCutscenePlayed = false;
        PlayFirstCutscene();
    }

    public void PlayFirstCutscene()
    {
        StartCoroutine(WaitFor(1)); // waiting for 1 second

        dialogueManager.StartDialogue(livingRoomSceneDialogue);
        while (dialogueManager.dialogueRunning)
        {
            StartCoroutine(WaitFor()); // waiting a single frame
        }

        bedroomScene.SetActive(true); // enabling all objects required by
                                      // bedroom scene
        bedroomScene.GetComponent<Animator>().SetTrigger("FadeInTrigger");
        // running fading in animation on all of them

        StartCoroutine(WaitFor(2));

        livingRoomScene.SetActive(false); // disabling all objects required by
                                          // living room scene as they are no
                                          // longer needed

        dialogueManager.StartDialogue(bedroomSceneDialogue);
        while (dialogueManager.dialogueRunning)
        {
            StartCoroutine(WaitFor());
        }

        bedroomScene.GetComponent<CanvasGroup>().interactable = true; 
        // enabling interaction at the end of First Scene
    }

    public void PlaySecondCutscene()
    {
        if (!secondCutscenePlayed)
        {
            GetComponent<PlayableDirector>().Play();
            secondCutscenePlayed = true;

            StartCoroutine(WaitFor(1));

            dialogueManager.StartDialogue(endSecondSceneDialogue);
            while (dialogueManager.dialogueRunning)
            {
                StartCoroutine(WaitFor());
            }

            browserCanvasGroup.interactable = true;
        }
    }

    IEnumerator WaitFor(int seconds = 0)
    /* This function is used for simple time delays
     */
    {
        if (seconds <= 0)
        {
            yield return null; // waiting a single frame
        }
        else
        {
            yield return new WaitForSeconds(seconds); // waiting for
                                                      // 'seconds' seconds
        }
    }
}


