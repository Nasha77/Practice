using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine.TextCore.Text;
using static CharacterRef;
using static WeaponRef;
using static EnemyRef;
using static WaveSpawnerRef;

public class DataManager : MonoBehaviour
{
    //load ref data from the file
    public void LoadRefData()
    {
        //for CHARCTERS

        string filePathCharacter = Path.Combine(Application.dataPath, "GameSystem/Data/characterRef.json"); //where to get files from
        string dataStringCharacter = File.ReadAllText(filePathCharacter);//read the path and save it in the data string

        Debug.Log("filePath" + filePathCharacter + "\n" + dataStringCharacter);
        CharcterDataList characterData = JsonUtility.FromJson<CharcterDataList>(dataStringCharacter); //converts datastring json into charcterref script data, the text file is converted into the charcter ref object
        List<Character> characterList = new List<Character>();

        //process ref data convert data read into classes
        foreach (CharacterRef charcterref in characterData.characterRef)
        {
            Character character = new Character(
                charcterref.characterId,
                charcterref.characterName,
                charcterref.description,
                charcterref.characterHealth,
                charcterref.characterAtk,
                charcterref.characterSpeed
                );
            characterList.Add(character);
            Debug.Log("ADD charcter " + character.characterName + " hp " + character.characterHealth); //debugger

        }
        Game.SetCharacterList(characterList);

        //for WEAPON

        string filePathWeapon = Path.Combine(Application.dataPath, "GameSystem/Data/weaponRef.json"); // Where to get files from
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
                weaponRef.description

            );
            weaponList.Add(weapon);
            Debug.Log("ADD charcter " + weapon.weaponName + " atk " + weapon.weaponATK); //debugger


        }

        Game.SetWeaponList(weaponList);

        //for ENEMY

        string filePathEnemy = Path.Combine(Application.dataPath, "GameSystem/Data/enemyRef.json");
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


        string filePathWave = Path.Combine(Application.dataPath, "GameSystem/Data/waveRef.json");
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
            Debug.Log("Added wave " + wave.waveName + " with enemy count " + wave.enemyCount); // Example debug log


        }
        Game.SetWeaponList(weaponList);

    }
}
