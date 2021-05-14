// Author: Cybaware - Fatima

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
/*  This class is a central dialogue managment system for Scenario 1. It runs 
 *  any dialogues passed to it on any dialogue box of choice.
 */

{
    public bool dialogueRunning;

    public Text dialogueText;
    public Animator dialogueBoxAnimator;

    private Queue<string> sentences; // A queue that holds a dialogue's
                                     // individual sentences

    void Awake()
    {
        sentences = new Queue<string>();
        dialogueRunning = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // if left mouse button is pressed
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueRunning = true;
        dialogueBoxAnimator.SetBool("isOpen", true); // running fading in
                                                     // animation for dialogue
                                                     // box and text

        sentences.Clear(); // emptying queue of any sentences from the previous
                           // dialogue

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    /*  This function displays the next sentence in the dialogue (or the next 
     *  sentence to dequeue in sentences queue).
     */
    {
        if (sentences.Count == 0) // if no sentences remain to display
        {
            EndDialogue();
            return;
        }

        StopAllCoroutines(); // stopping any previously running sentence -
                             // stopping TypeSentence function if running
        StartCoroutine(TypeSentence(sentences.Dequeue())); // displaying next
                                                           // sentence with the
                                                           // required delays
    }

    IEnumerator TypeSentence(string sentence)
    /*  This function displays a sentence with a typing animation.
     */
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null; // waiting a single frame
        }
    }

    public void EndDialogue()
    {
        dialogueBoxAnimator.SetBool("isOpen", false); // fading out dialogue
                                                      // box and text
        dialogueRunning = false;
    }


}
