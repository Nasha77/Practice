using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText; // Text element to show dialogue
    public Text leftSpeakerNameText; // Text element to show left speaker's name
    public Text rightSpeakerNameText; // Text element to show right speaker's name
    public Button nextButton; // Button to go to next dialogue

    private Queue<DialogueRef> dialogues; // Queue to manage dialogues
    

    void Start()
    {

        Debug.Log("DialogueManager am i working?");
        List<DialogueRef> testDialogues = Game.GetDialogueList();// Get all data foor dialogue
        {
            // Initialize the dialogue queue
            dialogues = new Queue<DialogueRef>();
            Debug.Log("DialogueManager initializing...");
        }

        if (testDialogues == null || testDialogues.Count == 0)
        {
            Debug.LogError("Test dialogues list is null or empty!");
            return;
        }

        // Add a listener to the next button to call DisplayNextDialogue when clicked
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(DisplayNextDialogue);
        }
        else
        {
            Debug.LogError("Next button is not assigned!");
        }
    }
    
    public void StartDialogue(List<DialogueRef> dialogueRefs)
    {
        Debug.Log("DialogueManager starting dialogue sequence...");

        // Initialize the dialogue queue again just in case
        dialogues = new Queue<DialogueRef>();

        // Check if the dialogue list is null or empty
        if (dialogueRefs == null || dialogueRefs.Count == 0)
        {
            Debug.LogError("dialogueRefs is null or empty!");
            return;
        }

        // Add each dialogue to the queue
        foreach (DialogueRef dialogue in dialogueRefs)
        {
            // Skip null dialogues
            if (dialogue == null)
            {
                Debug.LogError("One of the dialogueRefs is null!");
                continue;
            }
            dialogues.Enqueue(dialogue);
        }

        // Log the number of dialogues
        Debug.Log("Starting Dialogue with " + dialogues.Count + " entries");

        // Show the first dialogue
        DisplayNextDialogue();
    }

    public void DisplayNextDialogue()
    {
        Debug.Log("DisplayNextDialogue called.");

        // Check if there are no more dialogues
        if (dialogues.Count == 0)
        {
            EndDialogue(); // End the dialogue sequence
            return;
        }

        //dies here
        // Get the next dialogue from the queue
        DialogueRef currentDialogue = dialogues.Dequeue();
        Debug.Log("Displaying Dialogue ID: " + currentDialogue.cutsceneRefId);

        // Check if UI elements are assigned
        if (dialogueText == null || leftSpeakerNameText == null || rightSpeakerNameText == null)
        {
            Debug.LogError("UI elements are not assigned in the Inspector!");
            return;
        }

        // Update UI text elements with current dialogue information
        dialogueText.text = currentDialogue.dialogue;
        leftSpeakerNameText.text = currentDialogue.leftSpeaker;
        rightSpeakerNameText.text = currentDialogue.rightSpeaker;

       
       

        // Log the remaining number of dialogues in the queue
        Debug.Log("Remaining dialogues in queue: " + dialogues.Count);
    }

    void EndDialogue()
    {
        Debug.Log("End of Dialogue");

        // Clear the dialogue text
        dialogueText.text = "";
        leftSpeakerNameText.text = "";
        rightSpeakerNameText.text = "";

    }
}

