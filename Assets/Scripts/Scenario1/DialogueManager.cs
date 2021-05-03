using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
/*  This class is a central dialogue managing system. It runs any dialogues 
    passed to it on any dialogue box of choice. Since it is static and is used 
    to apply singleton pattern, it can be used anywhere in the entire Cybaware 
    system.
*/

{
    static public DialogueManager instance;
    static public bool dialogueRunning;

    public Text dialogueText;
    public Animator dialogueBoxAnimator;

    private Queue<string> sentences;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            sentences = new Queue<string>();
            dialogueRunning = false;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueRunning = true;
        dialogueBoxAnimator.SetBool("isOpen", true);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        StopAllCoroutines(); // TypeSentence function stopped if already
                             // running
        StartCoroutine(TypeSentence(sentences.Dequeue()));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null; // Waiting a single frame
        }
    }

    public void EndDialogue()
    {
        dialogueBoxAnimator.SetBool("isOpen", false);
        dialogueRunning = false;
    }


}
