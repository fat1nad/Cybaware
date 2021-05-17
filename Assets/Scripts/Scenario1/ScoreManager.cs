// Author: Cybaware - Fatima

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
/* This class is the central score management system for Scenario 1. It keeps 
 * track of all learning outcomes, positive and negative choices and the 
 * consequent score.
 */
{
    public LearningOutcome[] learningOutcomes;
    public Text scoreText;
    public DialogueManager dialogueManager;

    private int score;

    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString(); // displaying
                                                       // score
    }

    public void AddPosInteraction(string learningOutcome)
    {
        foreach (LearningOutcome lo in learningOutcomes)
        {
            if (lo.name == learningOutcome)
            {
                lo.posInteractions += 1;
                score += 1; // positive scoring
                scoreText.text = "Score: " + score.ToString(); // updating
                                                               // score

                if (lo.posInteractions == 1)
                {
                    dialogueManager.StartDialogue(lo.approval);
                }
                else
                {
                    dialogueManager.HaltDialogue(); // forced stop of any
                                                    // previously running
                                                    // dialogue
                }
            }
        }
    }

    public void AddNegInteraction(string learningOutcome)
    {
        foreach (LearningOutcome lo in learningOutcomes)
        {
            if (lo.name == learningOutcome)
            {
                lo.negInteractions += 1;
                
                if (lo.negInteractions == 1)
                {
                    dialogueManager.StartDialogue(lo.warning);
                }
                else
                {
                    dialogueManager.HaltDialogue(); // forced stop of any
                                                    // previously running
                                                    // dialogue

                    score -= 1; // negative scoring
                    scoreText.text = "Score: " + score.ToString(); // updating
                                                                   // score
                }
            }
        }
    }

}
