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

    }

    //CHARCTER save and load
    //now i only sayaing player's current charcter

    //saving
    public void SavePlayerData()
    {
        string filePath = Application.persistentDataPath; //where to save the data persisitant datapath will not work at datapath
        string fileName = "SaveData.txt"; //create a file 

        DynamicData dynamicData = MakeSaveData(Game.GetPlayer());
        WriteData<DynamicData>(Path.Combine(filePath, fileName), dynamicData);//write all data into the dynamic data into the file
    }

    private DynamicData MakeSaveData(Player player) //convert datamanager class to dynamic data
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
        //funtion
        string filePathCharacter = Application.persistentDataPath; //where to get files from
        string fileName = "SaveData.txt";
        Debug.Log("LOADDATAAAAAAAAAAAA" + Path.Combine(filePathCharacter, fileName));


        if (File.Exists(Path.Combine(filePathCharacter, fileName))) //when player enter the game this data file might not exsist so we have to check it
        {
            DynamicData dynamicData = ReadData<DynamicData>(Path.Combine(filePathCharacter, fileName));//get danaymic data from json

            Game.SetPlayer(LoadSaveData(dynamicData)); //set it as the main player if there is a exsistinf file
            return true; //exist
        }

        return false; //does not exist dyanamicdata

        //List<Character> characterList = new List<Character>();

    }

    private Player LoadSaveData(DynamicData dynamicData)
    {
        Player player = new Player(dynamicData.id, dynamicData.currentCharacter, dynamicData.currentCharacterWeapon);

        return player;
    }

    //CHARCTER read and write
    public T ReadData<T>(string filePathCharacter) //loading done using readdata
    {
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
    {
        string filePath = Application.persistentDataPath;
        string fileName = "SaveData.txt";
        string fullPath = Path.Combine(filePath, fileName);

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
            Debug.Log("Save file deleted successfully.");
        }
        else
        {
            Debug.LogWarning("Save file does not exist.");
        }
    }

}

