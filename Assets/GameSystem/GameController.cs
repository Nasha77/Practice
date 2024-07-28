//Nasha
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// GameController class, responsible for managing the game's state and flow.
public class GameController : MonoBehaviour
{
    public DataManager dataManager; // Reference to the DataManager, which handles data loading and saving.

    // Initial character and weapon to be used when creating a new player.
    public string initCharacter; // Set in inspector
    public string initWeapon;

    // Static reference to the GameController instance, so that only one instance exists.
    public static GameController instanceRef;


    // Called when the script is initialized.
    void Awake()
    {
        // Check if an instance of GameController already exists.
        if (instanceRef == null)
        {
            // If not, set this script as the instance and prevent it from being destroyed when scenes change.
            instanceRef = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instanceRef != this)
        {
            // If an instance already exists, destroy this script to prevent duplicates.
            Destroy(gameObject);
        }

        // Get the DataManager component and load reference data from datamanager script
        dataManager = GetComponent<DataManager>();
        dataManager.LoadRefData();

        // Check if save data exists
        if (dataManager.LoadPlayerData())
        {
            // If save data exists, go to GameScene
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            // If no save data exists, initialize new player and go to character selection
            Game.SetPlayer(new Player("1", initCharacter, initWeapon));
            Game.GetPlayer().GetCurrentCharacter();
        }

    }

    // retry button
    public void RetryButton()
    {
        // Check if save data exists
        if (dataManager.LoadPlayerData())
        {
            // If save data exists, navigate to gamescene
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            // If no save data exists, initialize new player
            Game.SetPlayer(new Player("1", initCharacter, initWeapon));
            Game.GetPlayer().GetCurrentCharacter();
        }
    }

    // restart button
    public void RestartButton()
    {
        // Delete save data and load the CONVO 1 scene.
        dataManager.DeleteSaveData();
    }
}
