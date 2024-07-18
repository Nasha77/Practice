using System.Collections; // Imports basic collection types.
using System.Collections.Generic; // Imports lists and dictionaries.
using UnityEngine; // Imports Unity-specific classes and functions.

[System.Serializable] // Allows this class to show up in Unity's Inspector.
public class DialogueRef
{
    // Public variables that store information about dialogue.
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
        // A list of DialogueRef objects.
        public List<DialogueRef> dialogueRef;
    }
}

