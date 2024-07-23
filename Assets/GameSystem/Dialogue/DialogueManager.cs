using System.Collections; // Import the System.Collections namespace
using System.Collections.Generic; // Import the System.Collections.Generic namespace
using UnityEngine; // Import the UnityEngine namespace
using UnityEngine.UI; // Import the UnityEngine.UI namespace

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText; // Text element to show dialogue
    public Text leftSpeakerNameText; // Text element to show left speaker's name
    public Text rightSpeakerNameText; // Text element to show right speaker's name
    public Button nextButton; // Button to go to next dialogue

    private Queue<DialogueRef> dialogues; // Queue to manage dialogues

    void Start()
    {
        // Initialize the dialogue queue
        dialogues = new Queue<DialogueRef>();
        Debug.Log("DialogueManager initializing...");

        // Load dialogues from the Game class
        List<DialogueRef> dialogueRefs = Game.GetDialogueList();

        // Check if the dialogue list is null or empty
        if (dialogueRefs == null || dialogueRefs.Count == 0)
        {
            Debug.LogError("Dialogue list is null or empty!");
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

        // Start the dialogue sequence with the loaded dialogues
        StartDialogue(dialogueRefs);
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