using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenePlayer : MonoBehaviour
{
    public Dialogue livingRoomSceneDialogue;
    public Dialogue bedroomSceneDialogue;
    public GameObject livingRoomScene;
    public GameObject bedroomScene;
    public Button laptop;
    //public GameObject internetSurferButton;

    void Start()
    {
        StartCoroutine(PlayFirstScene());
    }

    IEnumerator PlayFirstScene()
    {
        yield return new WaitForSeconds(1);

        DialogueManager.instance.StartDialogue(livingRoomSceneDialogue);

        while (DialogueManager.dialogueRunning)
        {
            yield return null;
        }

        bedroomScene.SetActive(true);
        laptop.interactable = false;

        bedroomScene.GetComponent<Animator>().SetTrigger("sceneChange");
        
        yield return new WaitForSeconds(2);

        livingRoomScene.SetActive(false);

        DialogueManager.instance.StartDialogue(bedroomSceneDialogue);

        while (DialogueManager.dialogueRunning)
        {
            yield return null;
        }

        laptop.interactable = true;

        //internetSurferButton.SetActive(true); //not part of first scene
        //anymore

        //SceneManager.LoadScene("EndLevel");
    }
}
