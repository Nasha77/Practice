using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public DataManager dataManager;
    public SelectionManager selectionManager;

    public string initCharacter; // set in inspector
    public string initWeapon;

    public static GameController instanceRef;

    void Awake()
    {
        if (instanceRef == null)
        {
            instanceRef = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instanceRef != this)
        {
            Destroy(gameObject);
        }

        dataManager = GetComponent<DataManager>();
        dataManager.LoadRefData();

        // Check if there is saved data and load it, or set default character and weapon
        if (!dataManager.LoadPlayerData())
        {
            Game.SetPlayer(new Player("1", initCharacter, initWeapon));
        }

        // Ensure the current character is set
        Game.GetPlayer().GetCurrentCharacter();

        Debug.Log("NOW " + initCharacter);
        Debug.Log("NOW " + initWeapon);

        Debug.Log("Character count: " + Game.GetCharacterList().Count);
        Debug.Log("Weapon count: " + Game.GetWeaponList().Count);

        // Load the game scene if save data exists
        LoadInitialScene();
    }

    void LoadInitialScene()
    {
        // If the player data was loaded successfully, go to the game scene
        if (dataManager.LoadPlayerData())
        {
            SceneManager.LoadScene("GameScene"); // Replace "GameScene" with the actual name of your game scene
        }
        else
        {
            // If no saved data, go to character selection
            SceneManager.LoadScene("CONVO 1"); // Replace "CharacterSelectionScene" with the actual name of your character selection scene
        }
    }
}
