// NASHA, KEE POH KUN

// This script, DataManager, handles the loading and saving of game data in Unity. It interacts with various other scripts
// that define characters, weapons, enemies, waves, dialogues, and quests to initialize game data from JSON files, 
// save player progress, and load player progress. It ensures that all game data is correctly processed, stored, and 
// retrieved, allowing for persistent game. The script also handles analytics data related to 
// saves and deletions for tracking player progress and behavior.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using UnityEngine.TextCore.Text;
using static CharacterRef;
using static WeaponRef;
using static EnemyRef;
using static WaveSpawnerRef;
using static DialogueRef;
using static QuestRef;
using System;

public class DataManager : MonoBehaviour
{
    private int saveCount = 0; // Track the number of times the game has been saved which saves a save.txt
    private int deleteCount = 0; // Track the number of times the game has been restarted which deletes a save.txt
    private int currentWaveId; // Stores the wave ID that player dies on referencing to wavemanager method


    // Load reference data from JSON files
    // This method is used to load all the necessary data for the game, such as characters, weapons, enemies, waves, dialogues, and quests
    public void LoadRefData() // Data needed for the game itself
    {
        // For CHARACTERS
        // Load character data from CharacterRef.json
        string filePathCharacter = Path.Combine(Application.streamingAssetsPath + "/CharacterRef.json"); // Where to get files from
        string dataStringCharacter = File.ReadAllText(filePathCharacter); // Read the path and save it in the data string
        CharcterDataList characterData = JsonUtility.FromJson<CharcterDataList>(dataStringCharacter);

        // Create a list to store character objects
        List<Character> characterList = new List<Character>();

        // // Process character data and create character objects
        foreach (CharacterRef characterref in characterData.characterRef)
        {
            // Create a new character object
            Character character = new Character(
                characterref.characterId,
                characterref.characterName,
                characterref.description,
                characterref.characterHealth,
                characterref.characterAtk,
                characterref.characterSpeed,
                characterref.characterSprite
            );

            // Add the character object to the list
            characterList.Add(character);
        }

        // Set the character list in the Game script
        Game.SetCharacterList(characterList);

        // For WEAPON
        // Load weapon data from WeaponRef.json
        string filePathWeapon = Path.Combine(Application.streamingAssetsPath + "/WeaponRef.json"); // Where to get files from
        string dataStringWeapon = File.ReadAllText(filePathWeapon); // Read the path and save it in the data string
        WeaponDataList weaponData = JsonUtility.FromJson<WeaponDataList>(dataStringWeapon); // Converts data string JSON into WeaponDataList script data

        List<Weapon> weaponList = new List<Weapon>();

        // Process reference data: convert data read into classes
        foreach (WeaponRef weaponRef in weaponData.weaponRef)
        {
            Weapon weapon = new Weapon(
                weaponRef.weaponID,
                weaponRef.characterId,
                weaponRef.weaponName,
                weaponRef.weaponATK,
                weaponRef.description,
                weaponRef.weaponSprite
            );
            weaponList.Add(weapon);
            
        }
        Game.SetWeaponList(weaponList);

        // For ENEMY
        string filePathEnemy = Path.Combine(Application.streamingAssetsPath + "/EnemyRef.json");
        string dataStringEnemy = File.ReadAllText(filePathEnemy);
        EnemyRef.EnemyDataList enemyData = JsonUtility.FromJson<EnemyRef.EnemyDataList>(dataStringEnemy);

        // Process reference data: convert data read into enemy objects
        List<Enemy> enemyList = new List<Enemy>();
        foreach (EnemyRef enemyRef in enemyData.enemyRef)
        {
            Enemy enemy = new Enemy(
                enemyRef.enemyId,
                enemyRef.enemyName,
                enemyRef.enemyHealth,
                enemyRef.enemyAtk,
                enemyRef.enemySpeed
               
            );
            enemyList.Add(enemy);
           
        }
        Game.SetEnemyList(enemyList);

        // For WAVE
        string filePathWave = Path.Combine(Application.streamingAssetsPath + "/WaveSpawnRef.json");
        string dataStringWave = File.ReadAllText(filePathWave);
        WaveSpawnerRef.WaveDataList waveData = JsonUtility.FromJson<WaveSpawnerRef.WaveDataList>(dataStringWave);

        // Process reference data: convert data read into wave objects
        List<WaveSpawnerRef> waveList = new List<WaveSpawnerRef>();
        foreach (WaveSpawnerRef waveRef in waveData.waveSpawner)
        {
            WaveSpawnerRef wave = new WaveSpawnerRef
            {
                waveId = waveRef.waveId,
                waveName = waveRef.waveName,
                enemyId = waveRef.enemyId,
                enemyCount = waveRef.enemyCount,
                totalHP = waveRef.totalHP
            };
            waveList.Add(wave);
            // Debug.Log("Added wave " + wave.waveName + " with enemy count " + wave.enemyCount); // Example debug log
        }
        Game.SetWaveList(waveList);

        // For DIALOGUE
        string filePathDialogue = Path.Combine(Application.streamingAssetsPath + "/DialogueRef.json");
        string dataStringDialogue = File.ReadAllText(filePathDialogue);
        DialogueRef.DialogueDataList dialogueData = JsonUtility.FromJson<DialogueRef.DialogueDataList>(dataStringDialogue);

        List<DialogueRef> dialogueList = new List<DialogueRef>();
        foreach (DialogueRef dialogueRef in dialogueData.dialogueRef)
        {
            DialogueRef thisLine = new DialogueRef
            {
                cutsceneRefId = dialogueRef.cutsceneRefId,
                cutSceneSetID = dialogueRef.cutSceneSetID,
                nextcutsceneRefId = dialogueRef.nextcutsceneRefId,
                currentSpeaker = dialogueRef.currentSpeaker,
                leftSpeaker = dialogueRef.leftSpeaker,
                rightSpeaker = dialogueRef.rightSpeaker,
                dialogue = dialogueRef.dialogue,
            };
            // Debug.Log(thisLine.dialogue);
            dialogueList.Add(thisLine);
        }
        Game.SetDialogueList(dialogueList); // Set dialogue list 

        // For QUEST
        string filePathQuest = Path.Combine(Application.streamingAssetsPath + "/QuestRef.json"); // Where to get files from
        Debug.Log(filePathQuest);
        string dataStringQuest = File.ReadAllText(filePathQuest); // Read the path and save it in the data string
        QuestDataList questData = JsonUtility.FromJson<QuestDataList>(dataStringQuest);

        List<Quest> questList = new List<Quest>();

        // Process ref data: convert data read into classes
        foreach (QuestRef questref in questData.questRef)
        {
            Quest quest = new Quest(
                questref.questId,
                questref.questName,
                questref.questDescription,
                questref.questReward
            );
            questList.Add(quest);
            
        }
        Game.SetQuestList(questList);
    }

    //saving
    // This method saves the player's data to file
    public void SavePlayerData()
    {
        // Get the file path and name for the save data
        string filePath = Application.persistentDataPath;
        string fileName = "SaveData.txt";

        // Create a DynamicData object to hold the player's data
        DynamicData dynamicData = MakeSaveData(Game.GetPlayer());

        // Write the DynamicData object to the save file
        WriteData<DynamicData>(Path.Combine(filePath, fileName), dynamicData);

        Debug.Log("SaveData.txt file path: " + Path.Combine(filePath, fileName));
        // Increment the save count
        saveCount++;

        // Write analytics data to track the save action which is a button player presses
        WriteAnalyticsData<DynamicData>(Path.Combine(Application.persistentDataPath, "analytics.txt"), dynamicData, saveCount, deleteCount);
    }


    // This method creates a DynamicData object to hold the player's data saved and used in save.txt
    private DynamicData MakeSaveData(Player player)
    {
        // Create a new DynamicData object
        DynamicData dynamicData = new DynamicData();

        // Set the player's ID, current character, and current character weapon in the DynamicData object
        dynamicData.id = player.GetId();
        dynamicData.currentCharacter = player.GetCurrentCharacter();
        dynamicData.currentCharacterWeapon = player.GetCurrentCharacterWeapon();


        // Return the DynamicData object
        return dynamicData;
    }


    //loading
    // This method loads the player's data from a file
    public bool LoadPlayerData()
    {
        // Get the file path and name for the save data
        string filePathCharacter = Application.persistentDataPath;
        string fileName = "SaveData.txt";

        // Check if the save file exists
        if (File.Exists(Path.Combine(filePathCharacter, fileName)))
        {
            // Read the DynamicData object from the save file
            DynamicData dynamicData = ReadData<DynamicData>(Path.Combine(filePathCharacter, fileName));

            // Set the player's data in the Game script
            Game.SetPlayer(LoadSaveData(dynamicData));

            // Return true to show that the data was loaded successfully SUCCESSFUL
            return true;
        }

        // Return false to show that the data was not loaded successfully UNSUCCESSFUL
        return false;
    }


    // This method creates a Player object from a DynamicData object
    private Player LoadSaveData(DynamicData dynamicData)
    {
        // Create a new Player object
        Player player = new Player(dynamicData.id, dynamicData.currentCharacter, dynamicData.currentCharacterWeapon);

        // Return the Player object
        return player;
    }

    //ANALYTICS
    // This method writes analytics data to track the player's actions
    public void WriteAnalyticsData<T>(string filePathAnalytics, T data, int saveNumber, int deleteNumber)
    {
        // Convert the data to a JSON string
        string dataStringAnalytics = JsonUtility.ToJson(data);

        // Get the current time
        string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        // Create a string to hold the analytics data
        string labeledData = $"Save {saveNumber} - {currentTime}: {dataStringAnalytics}";

        // Get the current wave ID
        int currentWaveId = GetCurrentWaveIndex();


        // Check if the analytics file exists
        if (File.Exists(filePathAnalytics))
        {
            // Read the existing analytics data
            string existingData = File.ReadAllText(filePathAnalytics);

            // Append the new analytics data to the existing data
            dataStringAnalytics = existingData + Environment.NewLine + labeledData;
        }

        // Write the analytics data to the file ANALYTICS.TXT
        File.AppendAllText(filePathAnalytics, labeledData + Environment.NewLine);
        File.AppendAllText(filePathAnalytics, "Number of saves: " + saveCount + Environment.NewLine);
        File.AppendAllText(filePathAnalytics, "Wave ID: " + currentWaveId + Environment.NewLine);

    }

    //CHARCTER read and write
    // This method reads data from a file
    public T ReadData<T>(string filePathCharacter)
    {
        // Check if the file is the save data file
        if (Path.GetFileName(filePathCharacter) != "SaveData.txt")
        {
            // Throw an exception if the file is not the save data file
            throw new InvalidOperationException("Can only read data from SaveData.txt");
        }

        // Read the data from the file
        string dataStringCharacter = File.ReadAllText(filePathCharacter);

        // Convert the data to a JSON object
        T data = JsonUtility.FromJson<T>(dataStringCharacter);

        // Return the data
        return data;
    }

    // This method writes data to a file
    // It is a generic method that can write any type of data to a file, cuz want to write different types of data to a file
    public void WriteData<T>(string filePathCharacter, T data)//saving done using write(in case you want to write different type of data)
    {

        // Convert the data to a JSON string
        // This is done using the JsonUtility.ToJson method, which converts the data into a JSON string
        string dataStringCharacter = JsonUtility.ToJson(data);

        //replace all text in the file into this data new text
        // This is done using the File.WriteAllText method, which overwrites the entire file with the new data
        File.WriteAllText(filePathCharacter, dataStringCharacter);
    }

    // Method to delete the save file
    public void DeleteSaveData()
    {
        //method to only delete the "SaveData.txt" file and not touch the "analytics.txt" file.
        // This method deletes the "SaveData.txt" file, but leaves the "analytics.txt" file intact do not delete analytics

        // Get the file path and name for the save data
        string filePathCharacter = Application.persistentDataPath;
        string fileName = "SaveData.txt";


        // Check if the save file exists
        if (File.Exists(Path.Combine(filePathCharacter, fileName)))
        {
            // Delete the save file
            File.Delete(Path.Combine(filePathCharacter, fileName));

            // Increment the delete count
            // This is used to keep track of how many times the save file has been deleted
            deleteCount++;

            // Log delete action in analytics
            // This is done by calling the LogDeleteAction method
            LogDeleteAction();
        }
    }


    // Method to log the delete action in analytics
    private void LogDeleteAction()
    {
        // Get the file path for the analytics data
        string filePathAnalytics = Path.Combine(Application.persistentDataPath, "analytics.txt");
        string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        // Create a string to log the delete action
        string deleteLog = $"RestartAction {deleteCount} - {currentTime}";

        // Append the delete log to the analytics file
        File.AppendAllText(filePathAnalytics, deleteLog + Environment.NewLine);
        
    }

    // Method to get the current wave index
    // This method returns the current wave index from the SpawnerManager script
    private int GetCurrentWaveIndex()
    {
        // Get the SpawnerManager script to get the index of wave
        SpawnerManager spawnerManager = GameObject.FindObjectOfType<SpawnerManager>();

        // Return the current wave index
        return spawnerManager.currentWaveIndex;
    }

    // Method to get the saved data as a formatted string
    public string GetSavedDataString()
    {
        string filePath = Application.persistentDataPath;
        string fileName = "SaveData.txt";

        if (File.Exists(Path.Combine(filePath, fileName)))
        {
            DynamicData dynamicData = ReadData<DynamicData>(Path.Combine(filePath, fileName));
            return $"ID: {dynamicData.id}\n" +
                   $"Character: {dynamicData.currentCharacter}\n" +
                   $"Weapon: {dynamicData.currentCharacterWeapon}";
        }
        else
        {
            return "No save data found.";
        }
    }

}