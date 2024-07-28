//Nasha
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// DialogueManager class responsible for handling dialogue sequences in the game.
public class DialogueManager : MonoBehaviour
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

    // Start method called when the DialogueManager is initialized.
    void Start()
    {
        // Initialize the dialogue queue
        dialogues = new Queue<DialogueRef>();

        // Retrieve all dialogues from the Game class
        List<DialogueRef> dialogueRefs = Game.GetDialogueList();

        // Filter the dialogues to include only those with cutSceneSetID 101
        List<DialogueRef> filteredDialogueRefs = dialogueRefs.FindAll(d => d.cutSceneSetID == 101);

        // Add a listener to the next button to call DisplayNextDialogue when clicked
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(DisplayNextDialogue);
        }

        // Start displaying the dialogues using the filtered list
        StartDialogue(filteredDialogueRefs);
    }

    // Method to start the dialogue sequence
    public void StartDialogue(List<DialogueRef> dialogueRefs)
    {

        // Reinitialize the dialogue queue to ensure it's empty
        dialogues = new Queue<DialogueRef>();

        // Enqueue each dialogue from the filtered list into the dialogue queue
        foreach (DialogueRef dialogue in dialogueRefs)
        {
            // Skip null dialogues
            if (dialogue == null)
            {
                continue;
            }
            dialogues.Enqueue(dialogue);
        }

        // Display the first dialogue in the queue
        DisplayNextDialogue();
    }

    // Method to display the next dialogue in the queue
    public void DisplayNextDialogue()
    {

        // Check if there are no more dialogues in the queue
        if (dialogues.Count == 0)
        {
            EndDialogue(); // End the dialogue sequence if the queue is empty
            return;
        }

        // Dequeue the next dialogue from the queue
        DialogueRef currentDialogue = dialogues.Dequeue();

        // Update the UI with the names of the left and right speakers
        leftSpeakerNameText.text = currentDialogue.leftSpeaker;
        rightSpeakerNameText.text = currentDialogue.rightSpeaker;

        // Update the UI with the name of the current speaker
        currentSpeakerText.text = currentDialogue.currentSpeaker == "Left" ? currentDialogue.leftSpeaker : currentDialogue.rightSpeaker;


        // If a typewriter coroutine is already running, stop it to prevent overlap.
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
        Debug.Log("End of Dialogue");

        // Clear the dialogue and speaker name texts in the UI
        dialogueText.text = "";
        leftSpeakerNameText.text = "";
        rightSpeakerNameText.text = "";
        currentSpeakerText.text = "";

        // Hide the next button when the dialogue ends
        if (nextButton != null)
        {
            // Deactivate the next button's game object to hide it.
            nextButton.gameObject.SetActive(false);
        }
       
        SceneManager.LoadScene("SelectionScene");
    }
}