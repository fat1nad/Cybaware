// Author: Cybaware - Fatima

using UnityEngine;

[System.Serializable]

public class LearningOutcome
/*  This class holds a learning outcome.
*/

{
    public string name; // name of learning outcome
    public int negInteractions = 0; // the number of times player went against
                                    // learning outcome
    public int posInteractions = 0; // the number of time player followed 
                                    // learning outcome
    public Dialogue warning; // warning if player went against learning outcome
                             // for the first time
    public Dialogue approval; // approval if player followed learning outcome
                              // for the first time
}
