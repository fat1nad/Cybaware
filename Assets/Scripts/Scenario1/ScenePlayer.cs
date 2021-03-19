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
        PlayFirstScene();
    }

    private void PlayFirstScene()
    {
        ExecuteAfterTime(1);

        DialogueManager.instance.StartDialogue(livingRoomSceneDialogue);

        while (DialogueManager.dialogueRunning){}

        laptopScene.SetActive(true);
        laptopScene.GetComponent<Animator>().SetTrigger("sceneChange");

        ExecuteAfterTime(1);

        DialogueManager.instance.StartDialogue(laptopSceneDialogue);
    }
    
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
