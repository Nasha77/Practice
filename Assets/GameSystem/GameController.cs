using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this to handle scene management

public class GameController : MonoBehaviour
{
    public DataManager dataManager; // Call the data
    public SelectionManager selectionManager; // Reference to SelectionManager script

    public string initCharacter; // Set in inspector
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

        Debug.Log(Game.GetCharacterList());

        // Check if save data exists
        if (dataManager.LoadPlayerData())
        {
            // If save data exists, navigate to the appropriate scene
            Debug.Log("Save data found, loading gamescene scene.");
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            // If no save data exists, initialize new player and go to character selection
            Game.SetPlayer(new Player("1", initCharacter, initWeapon));
            Game.GetPlayer().GetCurrentCharacter();

            // Initialize the character selection menu if needed
            selectionManager.InitializeMenu();
            Debug.Log("No save data found, going to character selection.");
        }

        Debug.Log("NOW " + initCharacter);
        Debug.Log("NOW " + initWeapon);
        Debug.Log("Character " + Game.GetCharacterList().Count);
        Debug.Log("Weapon " + Game.GetWeaponList().Count);
    }
}

