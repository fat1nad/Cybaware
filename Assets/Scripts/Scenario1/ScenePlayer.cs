// Author: Cybaware - Fatima

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenePlayer : MonoBehaviour
/* This class is used to play scenes for Scenario 1.
 */
{
    // all objects required for First Scene 
    public DialogueManager dialogueManager;
    public Dialogue livingRoomSceneDialogue;
    public Dialogue bedroomSceneDialogue;
    public GameObject livingRoomScene;
    public GameObject bedroomScene;

    void Start()
    {
        StartCoroutine(PlayFirstScene());
    }

    IEnumerator PlayFirstScene()
    {
        yield return new WaitForSeconds(1);

        dialogueManager.StartDialogue(livingRoomSceneDialogue);

        while (dialogueManager.dialogueRunning)
        {
            yield return null; // waiting a single frame
        }

        bedroomScene.SetActive(true); // enabling all objects required by
                                      // bedroom scene
        bedroomScene.GetComponent<Animator>().SetTrigger("FadeInTrigger");
        // running fading in animation on all of them

        yield return new WaitForSeconds(2);

        livingRoomScene.SetActive(false); // disabling all objects required by
                                          // living room scene as they are no
                                          // longer needed

        dialogueManager.StartDialogue(bedroomSceneDialogue);

        while (dialogueManager.dialogueRunning)
        {
            yield return null;
        }

        bedroomScene.GetComponent<CanvasGroup>().interactable = true; 
        // enabling interaction at the end of First Scene
    }
}


