using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePlayer : MonoBehaviour
{
    public Dialogue livingRoomSceneDialogue;
    public Dialogue laptopSceneDialogue;
    public GameObject laptopScene;
    public GameObject internetSurferButton;

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

        laptopScene.SetActive(true);
        laptopScene.GetComponent<Animator>().SetTrigger("sceneChange");

        yield return new WaitForSeconds(1);

        DialogueManager.instance.StartDialogue(laptopSceneDialogue);

        while (DialogueManager.dialogueRunning)
        {
            yield return null;
        }

        internetSurferButton.SetActive(true);

        //SceneManager.LoadScene("EndLevel");
    }
}
