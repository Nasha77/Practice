using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText; // UI Text element to display the dialogue text
    public Text leftSpeakerNameText; // UI Text element to display the left speaker's name
    public Text rightSpeakerNameText; // UI Text element to display the right speaker's name
    public GameObject[] choiceButtons; // Array of UI buttons for dialogue choices

    private Queue<DialogueRef> dialogues; // Queue to manage the dialogue sequences

    // Method called when the script instance is loaded
    void Start()
    {
        // Initialize the dialogue queue
        dialogues = new Queue<DialogueRef>();
        Debug.Log("DialogueManager am i Initializing"); // Log for initialization confirmation
    }

    // Method to start the dialogue sequence with a list of DialogueRef

    public void StartDialogue(List<DialogueRef> dialogueRefs)
    {
        Debug.Log("DialogueManager did i make it out alive?");
        // Check if the provided dialogueRefs list is null
        if (dialogueRefs == null)
        {
            Debug.LogError("dialogueRefs is null!"); // Log error if null
            return; // Exit the method
        }

        Debug.Log("DialogueManager am i still alive?");

        Debug.Log("DialogueManager did i die here? i died here huh"); //code died here

        Debug.Log("Starting Dialogue..."); // Log starting dialogue
        foreach (DialogueRef dialogue in dialogueRefs)
        {
            // Check if any dialogue in the list is null
            if (dialogue == null)
            {
                Debug.LogError("One of the dialogueRefs is null!"); // Log error if null
                continue; // Skip this dialogue and continue with the next
            }
            // Add each dialogue to the queue
            dialogues.Enqueue(dialogue);
        }

        // Log the number of dialogues in the queue
        Debug.Log("Starting Dialogue with " + dialogues.Count + " entries");
        // Display the first dialogue in the queue
        DisplayNextDialogue();
    }

    // Method to display the next dialogue in the queue
    public void DisplayNextDialogue()
    {
        // Check if there are no more dialogues in the queue
        if (dialogues.Count == 0)
        {
            // End the dialogue sequence
            EndDialogue();
            return; // Exit the method
        }

        // Get the next dialogue from the queue
        DialogueRef currentDialogue = dialogues.Dequeue();
        Debug.Log("Displaying Dialogue ID: " + currentDialogue.cutsceneRefId); // Log the current dialogue ID

        // Check if the UI elements are assigned
        if (dialogueText == null)
        {
            Debug.LogError("dialogueText is not assigned in the Inspector!"); // Log error if not assigned
            return; // Exit the method
        }
        if (leftSpeakerNameText == null)
        {
            Debug.LogError("leftSpeakerNameText is not assigned in the Inspector!"); // Log error if not assigned
            return; // Exit the method
        }
        if (rightSpeakerNameText == null)
        {
            Debug.LogError("rightSpeakerNameText is not assigned in the Inspector!"); // Log error if not assigned
            return; // Exit the method
        }

        // Update the UI text elements with the current dialogue information
        dialogueText.text = currentDialogue.dialogue; // Update dialogue text
        leftSpeakerNameText.text = currentDialogue.leftSpeaker; // Update left speaker name
        rightSpeakerNameText.text = currentDialogue.rightSpeaker; // Update right speaker name

        // If there are choices available in the current dialogue
        if (!string.IsNullOrEmpty(currentDialogue.choices))
        {
            // Split the choices string into an array
            string[] choices = currentDialogue.choices.Split('#');
            // Loop through the choice buttons and update their text
            for (int i = 0; i < choiceButtons.Length; i++)
            {
                if (i < choices.Length)
                {
                    choiceButtons[i].SetActive(true); // Activate the button
                    Text choiceText = choiceButtons[i].GetComponentInChildren<Text>(); // Get the Text component
                    choiceText.text = choices[i]; // Set the choice text
                }
                else
                {
                    choiceButtons[i].SetActive(false); // Deactivate the button if there are no more choices
                }
            }
        }
        else
        {
            // Deactivate all choice buttons if there are no choices
            foreach (GameObject button in choiceButtons)
            {
                button.SetActive(false);
            }
        }
    }

    // Method to handle the end of the dialogue sequence
    void EndDialogue()
    {
        Debug.Log("End of Dialogue"); // Log end of dialogue
        // Logic to end the dialogue, e.g., close the dialogue UI
    }
}
