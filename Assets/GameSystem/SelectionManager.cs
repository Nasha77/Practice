// KEE POH KUN

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SelectionManager : MonoBehaviour
{
    // UI Image component to display character images
    public Image image;

    // store character data
    private List<Character> characterText;

  
    //store sprites
    public List<Sprite> sprite;

    // track current character
    public int characterIndex = 0;

    //UI Text component to display character names
    public TextMeshProUGUI characterName;

    //reference to the SelectionManager instance
    public static SelectionManager instanceRef;

    // SpriteRenderer component to display the player sprite
    public SpriteRenderer playerSprite;


    void Start()
    {
        // Singleton pattern to ensure only one instance of SelectionManager exists
        if (instanceRef == null)
        {
            instanceRef = this;
            // Prevent this object from being destroyed on scene load
            DontDestroyOnLoad(gameObject);
        }
        else if (instanceRef != this)
        {
            // destroy duplicate instances
            Destroy(gameObject);
        }

        // initialize selection menu
        InitializeMenu();
    }

    // Initialize the character selection menu
    public void InitializeMenu()
    {
        // Get the list of characters from the game
        characterText = Game.GetCharacterList();

        // Update the UI with the current character information
        UpdateMenuText();
    }

    // Update the UI with the current character information
    private void UpdateMenuText()
    {
        // get data from excel
        // Set the character name text to the current character's name
        characterName.text = characterText[characterIndex].characterName;


        // Set the player sprite to the current character's sprite
        playerSprite.sprite = sprite[characterIndex];

    }

    // Select the next character in the list
    public void NextOption()
    {
        // incrememnt character index
        characterIndex++;
        if(characterIndex == characterText.Count)
        {
            // Loop back to the first character if the end of the list is reached
            characterIndex = 0;
        }
        // update UI with new info
        UpdateMenuText();

    }

    // Select the previous character in the list
    public void BackOption()
    {
        // Decrement the character index
        characterIndex--;
        if(characterIndex < 0)
        {
            // Loop to the last character if the beginning of the list is reached
            characterIndex = characterText.Count - 1;
        }

        //update with new info
        UpdateMenuText();

    }

    // go next scene once button plays
    public void PlayOption()
    {
        
        // Set the current character ID for player
        Game.GetPlayer().SetCurrentCharacter(characterText[characterIndex].characterId);
        

        // Set the current character weapon ID
        Game.GetPlayer().SetCurrentCharacterWeapon(Game.GetWeaponList()[characterIndex].weaponID);
        
        // load next scene
        SceneManager.LoadScene("CONVO 2");
    }



}
