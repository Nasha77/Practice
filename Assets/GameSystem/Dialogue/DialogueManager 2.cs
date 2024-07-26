using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager2 : MonoBehaviour
{
    // Reference to the UI Text element where the dialogue will be displayed
    public Text dialogueText;

    // Reference to the UI Text element where the left speaker's name will be displayed
    public Text leftSpeakerNameText;

    // Reference to the UI Text element where the right speaker's name will be displayed
    public Text rightSpeakerNameText;

    // Reference to the UI Text element where the current speaker's name will be displayed
    public Text currentSpeakerText;

    // Reference to the UI Button element that will be used to advance the dialogue
    public Button nextButton;

    // Speed of the typewriter effect, i.e., the delay between each character being displayed
    public float typewriterSpeed = 0.05f;

    // Queue to hold the dialogues to be displayed, ensuring they are processed in order
    private Queue<DialogueRef> dialogues;

    // Reference to the current typewriter coroutine, allowing it to be stopped if needed
    private Coroutine typewriterCoroutine;

    void Start()
    {
        // Initialize the dialogue queue
        dialogues = new Queue<DialogueRef>();
        Debug.Log("DialogueManager initializing...");

        // Retrieve all dialogues from the Game class
        List<DialogueRef> dialogueRefs = Game.GetDialogueList();

        // Filter the dialogues to include only those with cutSceneSetID 101
        List<DialogueRef> filteredDialogueRefs = dialogueRefs.FindAll(d => d.cutSceneSetID == 102);

        // Check if the filtered dialogue list is null or empty and log an error if it is
        if (filteredDialogueRefs == null || filteredDialogueRefs.Count == 0)
        {
            Debug.LogError("Filtered dialogue list is null or empty!");
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

        // Start displaying the dialogues using the filtered list
        StartDialogue(filteredDialogueRefs);
    }

    // Method to start the dialogue sequence
    public void StartDialogue(List<DialogueRef> dialogueRefs)
    {
        Debug.Log("DialogueManager starting dialogue sequence... count of dialogueRefs: "+dialogueRefs.Count);

        // Reinitialize the dialogue queue to ensure it's empty
        dialogues = new Queue<DialogueRef>();

        // Check if the provided dialogue list is null or empty and log an error if it is
        if (dialogueRefs == null || dialogueRefs.Count == 0)
        {
            Debug.LogError("dialogueRefs is null or empty!");
            return;
        }

        // Enqueue each dialogue from the filtered list into the dialogue queue
        foreach (DialogueRef dialogue in dialogueRefs)
        {
            // Skip null dialogues and log an error
            if (dialogue == null)
            {
                Debug.LogError("One of the dialogueRefs is null!");
                continue;
            }



            dialogues.Enqueue(dialogue);
        }

        // Log the number of dialogues that have been enqueued
        //Debug.Log("Starting Dialogue with " + dialogues.Count + " entries");

        // Display the first dialogue in the queue
        DisplayNextDialogue();
    }

    // Method to display the next dialogue in the queue
    public void DisplayNextDialogue()
    {
        Debug.Log("DisplayNextDialogue called.");

        // Check if there are no more dialogues in the queue
        if (dialogues.Count == 0)
        {
            EndDialogue(); // End the dialogue sequence if the queue is empty
            return;
        }

        // Dequeue the next dialogue from the queue
        DialogueRef currentDialogue = dialogues.Dequeue();
        //Debug.Log("Displaying Dialogue ID: " + currentDialogue.cutsceneRefId);

        // Check if UI elements are assigned and log an error if any are missing
        if (dialogueText == null || leftSpeakerNameText == null || rightSpeakerNameText == null || currentSpeakerText == null)
        {
            //Debug.LogError("UI elements are not assigned in the Inspector!");
            return;
        }

        // Update the UI with the names of the left and right speakers
        leftSpeakerNameText.text = currentDialogue.leftSpeaker;
        rightSpeakerNameText.text = currentDialogue.rightSpeaker;

        // Update the UI with the name of the current speaker
        currentSpeakerText.text = currentDialogue.currentSpeaker == "Left" ? currentDialogue.leftSpeaker : currentDialogue.rightSpeaker;

        // If a typewriter coroutine is already running, stop it
        if (typewriterCoroutine != null)
        {
            StopCoroutine(typewriterCoroutine);
        }

        // Start a new typewriter coroutine to display the dialogue text with the typewriter effect
        typewriterCoroutine = StartCoroutine(TypewriterEffect(currentDialogue.dialogue));
    }

    // Coroutine to implement the typewriter effect for the dialogue text
    private IEnumerator TypewriterEffect(string dialogue)
    {
        // Clear the current dialogue text
        dialogueText.text = "";

        // Loop through each character in the dialogue string
        foreach (char letter in dialogue.ToCharArray())
        {
            // Append the current character to the dialogue text
            dialogueText.text += letter;

            // Wait for a short duration before displaying the next character
            yield return new WaitForSeconds(typewriterSpeed);
        }
    }

    // Method to handle the end of the dialogue sequence
    void EndDialogue()
    {
       // Debug.Log("End of Dialogue");

        // Clear the dialogue and speaker name texts in the UI
        dialogueText.text = "";
        leftSpeakerNameText.text = "";
        rightSpeakerNameText.text = "";
        currentSpeakerText.text = "";

        // Hide the next button when the dialogue ends
        if (nextButton != null)
        {
            nextButton.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Next button is not assigned!");
        }

        SceneManager.LoadScene("GameScene");
    }


}