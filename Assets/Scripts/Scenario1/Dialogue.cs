using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Dialogue
/*  This class holds a dialogue in the form of several (2-10) sentences.
*/

{    
    [TextArea(2, 10)]
    public string[] sentences;
}
