using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueTester : MonoBehaviour
{
    public DialogueManager dialogueManager; // Reference to the DialogueManager

    // Method called when the script instance is loaded
    void Start()
    {
        // Check if the dialogueManager is assigned
        if (dialogueManager == null)
        {
            Debug.LogError("dialogueManager is not assigned in the Inspector!"); // Log error if not assigned
            return; // Exit the method
        }

        // Sample dialogues for testing
        List<DialogueRef> testDialogues = new List<DialogueRef>
        {
            new DialogueRef
            {
                cutsceneRefId = 10001,
                nextcutsceneRefId = 10002,
                currentSpeaker = "Left",
                leftSpeaker = "Cara",
                rightSpeaker = "Jush",
                dialogue = "I feel so refreshed after practising my guitar! What have you done today Jush?",
                choices = ""
            },
            new DialogueRef
            {
                cutsceneRefId = 10002,
                nextcutsceneRefId = 10003,
                currentSpeaker = "Right",
                leftSpeaker = "Cara",
                rightSpeaker = "Jush",
                dialogue = "BASEBALL BASEBALL I BATTED 10000000000000 METERS TODAY!",
                choices = ""
            }
        };

        // Check if the test dialogues list is null or empty
        if (testDialogues == null || testDialogues.Count == 0)
        {
            Debug.LogError("Test dialogues list is null or empty!"); // Log error if null or empty
            return; // Exit the method
        }

        // Start the dialogue sequence with the test data
        dialogueManager.StartDialogue(testDialogues);
    }
}