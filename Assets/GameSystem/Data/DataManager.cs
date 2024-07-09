using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine.TextCore.Text;
using static CharacterRef;
using static WeaponRef;

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


    }


    //process ref data convert data read into classes
    ////private void ProcessCharacterRef(CharacterRef characterData)
    ////{
    ////    List<Character> characterList = new List<Character>();

    ////    foreach (CharacterRef charcterref in characterData.characterRef)
    ////    {
    ////        Character character = new Character(charcterref.characterId, charcterref.characterName, charcterref.description, charcterref.characterHealth, charcterref.characterAtk, charcterref.characterSpeed);
    ////        characterList.Add(character);
    ////    }
    ////}
}
