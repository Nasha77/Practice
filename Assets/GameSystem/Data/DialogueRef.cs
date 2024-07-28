// Nasha
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

[System.Serializable] // Allows this class to show up in Unity's Inspector.
public class DialogueRef
{
    // Public variables that store information about dialogue
    public int cutSceneSetID;
    public int cutsceneRefId;
    public int nextcutsceneRefId;
    public string currentSpeaker;
    public string leftSpeaker;
    public string rightSpeaker;
    public string dialogue;
    

    [System.Serializable] // Allows this nested class to show up in Unity's Inspector.
    public class DialogueDataList
    {
        // A list of DialogueRef objects, used to store and manage a collection of dialogues in the game.
        public List<DialogueRef> dialogueRef; // Stores a list of DialogueRef objects, which are used to define the characteristics of each dialogue in the game. 
                                              // The name "dialogueRef" must match the name of the JSON file that contains the dialogue data or else.....headache

    }
}

