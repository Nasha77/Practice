//Nasha
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class Dialogue
{
    // These are the properties of the Dialogue class
    public int cutSceneSetID { get; } //Cut scene set ID
    public int cutsceneRefId { get; } // ID of the current cutscene.
    public int nextcutsceneRefId { get; } // ID of the next cutscene.
    public string currentSpeaker { get; } // Who is speaking right now.
    public string leftSpeaker { get; } // Who is on the left side.
    public string rightSpeaker { get; } // Who is on the right side.
    public string dialogue { get; } // The dialogue text.




    // This is the constructor for the Dialogue class
    public Dialogue(int cutSceneSetID, int cutsceneRefId, int nextcutsceneRefId, string currentSpeaker, string leftSpeaker, string rightSpeaker, string dialogue)
    {
        this.cutSceneSetID = cutSceneSetID;
        this.cutsceneRefId = cutsceneRefId; // Set the ID of the current cutscene.
        this.nextcutsceneRefId = nextcutsceneRefId; // Set the ID of the next cutscene.
        this.currentSpeaker = currentSpeaker; // Set who is speaking right now.
        this.leftSpeaker = leftSpeaker; // Set who is on the left side.
        this.rightSpeaker = rightSpeaker; // Set who is on the right side.
        this.dialogue = dialogue; // Set the dialogue text.
        


    }
}
