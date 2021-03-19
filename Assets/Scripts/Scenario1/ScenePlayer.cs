using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePlayer : MonoBehaviour
{
    public Dialogue livingRoomSceneDialogue;
    public Dialogue laptopSceneDialogue;
    public GameObject laptopScene;

    // Update is called once per frame
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
            Debug.Log(DialogueManager.dialogueRunning);
            yield return null;
        }

        laptopScene.SetActive(true);
        laptopScene.GetComponent<Animator>().SetTrigger("sceneChange");

        yield return new WaitForSeconds(1);

        DialogueManager.instance.StartDialogue(laptopSceneDialogue);
    }
}
