using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine.TextCore.Text;
using static WeaponRef;

public class DataManager : MonoBehaviour
{
    // Load reference data from the file
    public void LoadRefData()
    {
        // CHARACTER
        string filePathCharacter = Path.Combine(Application.dataPath, "GameSystem/Data/characterRef.json");
        string dataStringCharacter = File.ReadAllText(filePathCharacter);
        CharcterDataList characterData = JsonUtility.FromJson<CharcterDataList>(dataStringCharacter);
        List<Character> characterList = new List<Character>();

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
            Debug.Log("ADD character " + character.characterName + " hp " + character.characterHealth);
        }
        Game.SetCharacterList(characterList);

        // WEAPON
        string filePathWeapon = Path.Combine(Application.dataPath, "GameSystem/Data/weaponRef.json");
        string dataStringWeapon = File.ReadAllText(filePathWeapon);
        WeaponDataList weaponData = JsonUtility.FromJson<WeaponDataList>(dataStringWeapon);
        List<Weapon> weaponList = new List<Weapon>();

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
            Debug.Log("ADD weapon " + weapon.weaponName + " atk " + weapon.weaponATK);
        }
        Game.SetWeaponList(weaponList);

        // ENEMY
        string filePathEnemy = Path.Combine(Application.dataPath, "GameSystem/Data/enemyRef.json");
        string dataStringEnemy = File.ReadAllText(filePathEnemy);
        EnemyRef.EnemyDataList enemyData = JsonUtility.FromJson<EnemyRef.EnemyDataList>(dataStringEnemy);
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
            Debug.Log("Added enemy " + enemy.enemyName + " with health " + enemy.enemyHealth);
        }
        Game.SetEnemyList(enemyList);
    }
}

