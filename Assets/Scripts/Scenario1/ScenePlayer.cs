using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePlayer : MonoBehaviour
{
    public Dialogue livingRoomSceneDialogue;
    public Dialogue laptopSceneDialogue;
    public GameObject bedroomScene;
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
        bedroomScene.GetComponent<Animator>().SetTrigger("sceneChange");

        yield return new WaitForSeconds(1);

        DialogueManager.instance.StartDialogue(laptopSceneDialogue);

        while (DialogueManager.dialogueRunning)
        {
            yield return null;
        }

        //internetSurferButton.SetActive(true); //not part of first scene
                                                //anymore

        //SceneManager.LoadScene("EndLevel");
    }
}
