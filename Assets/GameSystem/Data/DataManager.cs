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
    //load ref data from the file
    public void LoadRefData() //data needed for the game its self
    {
        //for CHARCTERS



        string filePathCharacter = Path.Combine(Application.streamingAssetsPath + "/CharacterRef.json"); //where to get files from


        Debug.Log(filePathCharacter);

        string dataStringCharacter = File.ReadAllText(filePathCharacter); // Read the path and save it in the data string
        Debug.Log(dataStringCharacter);
        CharcterDataList characterData = JsonUtility.FromJson<CharcterDataList>(dataStringCharacter);

       

        List<Character> characterList = new List<Character>();

        //process ref data convert data read into classes
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
            Debug.Log("ADD charcter " + character.characterName + " hp " + character.characterHealth); //debugger

        }
        Game.SetCharacterList(characterList);

        //for WEAPON

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
            //Debug.Log("ADD charcter " + weapon.weaponName + " atk " + weapon.weaponATK); //debugger


        }

        Game.SetWeaponList(weaponList);

        //for ENEMY

        string filePathEnemy = Path.Combine(Application.streamingAssetsPath + "/EnemyRef.json");

       


        string dataStringEnemy = File.ReadAllText(filePathEnemy);
 
        // Parse JSON data into EnemyDataList
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

        // Assuming there's a method to set the enemy list in your game system
        Game.SetEnemyList(enemyList);

        //for WAVE


        string filePathWave = Path.Combine(Application.streamingAssetsPath + "/WaveSpawnRef.json");



        string dataStringWave = File.ReadAllText(filePathWave);

        


        // Parse JSON data into WaveDataList
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
            //Debug.Log("Added wave " + wave.waveName + " with enemy count " + wave.enemyCount); // Example debug log


        }
        Game.SetWaveList(waveList);

        //for DIALOGUE

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
            //Debug.Log(thisLine.dialogue);
            dialogueList.Add(thisLine);
        }
        Game.SetDialogueList(dialogueList); // Set dialogue list 


        // FOR QUEST

        string filePathQuest = Path.Combine(Application.streamingAssetsPath + "/QuestRef.json"); //where to get files from


        Debug.Log(filePathQuest);

        string dataStringQuest = File.ReadAllText(filePathQuest); // Read the path and save it in the data string
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" + dataStringQuest);
        QuestDataList questData = JsonUtility.FromJson<QuestDataList>(dataStringQuest);

        List<Quest> questList = new List<Quest>();

        //process ref data convert data read into classes
        foreach (QuestRef questref in questData.questRef)
        {
            Quest quest = new Quest(
                questref.questId,
                questref.questName,
                questref.questDescription,
                questref.questReward
                );
            questList.Add(quest);
            Debug.Log("ADD quest " + quest.questName + quest.questReward); //debugger

        }
        Game.SetQuestList(questList);
    }



    //CHARCTER save and load
    //now i only sayaing player's current charcter

    //saving
    public void SavePlayerData()
    {
        string filePath = Application.persistentDataPath;
        string fileName = "SaveData.txt";

        DynamicData dynamicData = MakeSaveData(Game.GetPlayer());
        WriteData<DynamicData>(Path.Combine(filePath, fileName), dynamicData);

        int saveNumber;
        string filePathAnalytics = Path.Combine(Application.persistentDataPath, "analytics.txt");
        if (File.Exists(filePathAnalytics))
        {
            string[] lines = File.ReadAllLines(filePathAnalytics);
            saveNumber = lines.Length + 1; // increment the save number based on the number of lines in the analytics file
        }
        else
        {
            saveNumber = 1; // start with save number 1 if the analytics file doesn't exist
        }

        WriteAnalyticsData<DynamicData>(Path.Combine(Application.persistentDataPath, "analytics.txt"), dynamicData, saveNumber);
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
    public void WriteAnalyticsData<T>(string filePathAnalytics, T data, int saveNumber)
    {
        string dataStringAnalytics = JsonUtility.ToJson(data);
        string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string labeledData = $"Save {saveNumber} - {currentTime}: {dataStringAnalytics}";

        if (File.Exists(filePathAnalytics))
        {
            string existingData = File.ReadAllText(filePathAnalytics);
            dataStringAnalytics = existingData + Environment.NewLine + labeledData;
        }

        File.AppendAllText(filePathAnalytics, labeledData + Environment.NewLine);
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
    public void WriteData<T>(string filePathCharacter, T data)//saveing done using write(inscae you want to write differnt type of data)
    {
        string dataStringCharacter = JsonUtility.ToJson(data);//convert T class data into Json convert to string
        Debug.Log(filePathCharacter + "/n" + dataStringCharacter);
        //replace all text in the file into this data new text
        File.WriteAllText(filePathCharacter, dataStringCharacter);
    }

    // Method to delete the save file
    public void DeleteSaveData()
    {//method to only delete the "SaveData.txt" file and not touch the "analytics.txt" file.
        string filePathCharacter = Application.persistentDataPath;
        string fileName = "SaveData.txt";

        if (File.Exists(Path.Combine(filePathCharacter, fileName)))
        {
            File.Delete(Path.Combine(filePathCharacter, fileName));
        }
    }

}