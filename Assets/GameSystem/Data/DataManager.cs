// NASHA, KEE POH KUN

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
    private int saveCount = 0; // to track the number of saves
    private int deleteCount = 0;
    private int currentWaveId;


    // Load ref data from the file
    public void LoadRefData() // Data needed for the game itself
    {
        // For CHARACTERS
        string filePathCharacter = Path.Combine(Application.streamingAssetsPath + "/CharacterRef.json"); // Where to get files from
        Debug.Log(filePathCharacter);
        string dataStringCharacter = File.ReadAllText(filePathCharacter); // Read the path and save it in the data string
        Debug.Log(dataStringCharacter);
        CharcterDataList characterData = JsonUtility.FromJson<CharcterDataList>(dataStringCharacter);

        List<Character> characterList = new List<Character>();

        // Process ref data: convert data read into classes
        foreach (CharacterRef characterref in characterData.characterRef)
        {
            Character character = new Character(
                characterref.characterId,
                characterref.characterName,
                characterref.description,
                characterref.characterHealth,
                characterref.characterAtk,
                characterref.characterSpeed,
                characterref.characterSprite
            );
            characterList.Add(character);
            Debug.Log("Added character " + character.characterName + " hp " + character.characterHealth); // Debugger
        }
        Game.SetCharacterList(characterList);

        // For WEAPON
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
            // Debug.Log("Added weapon " + weapon.weaponName + " atk " + weapon.weaponATK); // Debugger
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
                enemyRef.enemySpeed,
                enemyRef.enemyEXP
            );
            enemyList.Add(enemy);
            Debug.Log("Added enemy " + enemy.enemyName + " with health " + enemy.enemyHealth); // Example debug log
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
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" + dataStringQuest);
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
            Debug.Log("Added quest " + quest.questName + quest.questReward); // Debugger
        }
        Game.SetQuestList(questList);
    }

    //saving
    public void SavePlayerData()
    {
        string filePath = Application.persistentDataPath;
        string fileName = "SaveData.txt";

        DynamicData dynamicData = MakeSaveData(Game.GetPlayer());
        WriteData<DynamicData>(Path.Combine(filePath, fileName), dynamicData);

        // Increment the save count
        saveCount++;

        // Write analytics data
        WriteAnalyticsData<DynamicData>(Path.Combine(Application.persistentDataPath, "analytics.txt"), dynamicData, saveCount, deleteCount);
    }

    private DynamicData MakeSaveData(Player player)
    {
        DynamicData dynamicData = new DynamicData();
        dynamicData.id = player.GetId();
        dynamicData.currentCharacter = player.GetCurrentCharacter();
        dynamicData.currentCharacterWeapon = player.GetCurrentCharacterWeapon();
        
        

        return dynamicData;
    }

    //loading
    public bool LoadPlayerData()
    {
        string filePathCharacter = Application.persistentDataPath;
        string fileName = "SaveData.txt";
        Debug.Log("LOADDATAAAAAAAAAAAA" + Path.Combine(filePathCharacter, fileName));

        if (File.Exists(Path.Combine(filePathCharacter, fileName)))
        {
            DynamicData dynamicData = ReadData<DynamicData>(Path.Combine(filePathCharacter, fileName));

            Game.SetPlayer(LoadSaveData(dynamicData));
            return true;
        }

        return false;
    }

    private Player LoadSaveData(DynamicData dynamicData)
    {
        Player player = new Player(dynamicData.id, dynamicData.currentCharacter, dynamicData.currentCharacterWeapon);

        return player;
    }

    //ANALYTICS
    public void WriteAnalyticsData<T>(string filePathAnalytics, T data, int saveNumber, int deleteNumber)
    {
        string dataStringAnalytics = JsonUtility.ToJson(data);
        string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string labeledData = $"Save {saveNumber} - {currentTime}: {dataStringAnalytics}";
        // Get the current wave ID
        int currentWaveId = GetCurrentWaveIndex();


        if (File.Exists(filePathAnalytics))
        {
            string existingData = File.ReadAllText(filePathAnalytics);
            dataStringAnalytics = existingData + Environment.NewLine + labeledData;
        }

        File.AppendAllText(filePathAnalytics, labeledData + Environment.NewLine);
        File.AppendAllText(filePathAnalytics, "Number of saves: " + saveCount + Environment.NewLine);
        File.AppendAllText(filePathAnalytics, "Wave ID: " + currentWaveId + Environment.NewLine);



    }

    //CHARCTER read and write
    public T ReadData<T>(string filePathCharacter)
    {
        if (Path.GetFileName(filePathCharacter) != "SaveData.txt")
        {
            throw new InvalidOperationException("Can only read data from SaveData.txt");
        }

        string dataStringCharacter = File.ReadAllText(filePathCharacter);
        Debug.Log("filePath" + filePathCharacter + "\n" + dataStringCharacter);

        T data = JsonUtility.FromJson<T>(dataStringCharacter);

        return data;
    }

    public void WriteData<T>(string filePathCharacter, T data)//saving done using write(in case you want to write different type of data)
    {
        string dataStringCharacter = JsonUtility.ToJson(data);//convert T class data into Json convert to string
        Debug.Log(filePathCharacter + "/n" + dataStringCharacter);
        //replace all text in the file into this data new text
        File.WriteAllText(filePathCharacter, dataStringCharacter);
    }

    // Method to delete the save file
    public void DeleteSaveData()
    {
        //method to only delete the "SaveData.txt" file and not touch the "analytics.txt" file.
        string filePathCharacter = Application.persistentDataPath;
        string fileName = "SaveData.txt";

        if (File.Exists(Path.Combine(filePathCharacter, fileName)))
        {
            File.Delete(Path.Combine(filePathCharacter, fileName));

            // Increment the delete count
            deleteCount++;

            // Log delete action in analytics
            LogDeleteAction();
        }
    }

    private void LogDeleteAction()
    {
        string filePathAnalytics = Path.Combine(Application.persistentDataPath, "analytics.txt");
        string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string deleteLog = $"RestartAction {deleteCount} - {currentTime}";

        File.AppendAllText(filePathAnalytics, deleteLog + Environment.NewLine);
        
    }

    private int GetCurrentWaveIndex()
    {
        SpawnerManager spawnerManager = GameObject.FindObjectOfType<SpawnerManager>();
        return spawnerManager.currentWaveIndex;
    }


}