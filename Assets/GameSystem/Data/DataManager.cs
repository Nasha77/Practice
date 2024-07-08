using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine.TextCore.Text;

public class DataManager : MonoBehaviour
{
    //load ref data from the file
    public void LoadRefData()
    {
        string filePath = Path.Combine(Application.dataPath, "GameSystem/Data/CharacterRef.txt"); //where to get files from
        string dataString = File.ReadAllText(filePath);//read the path and save it in the data string

        CharacterRef characterData = JsonUtility.FromJson<CharacterRef>(dataString); //converts datastring json into charcterref script data, the text file is converted into the charcter ref object

    }


    //process ref data convert data read into classes
    private void ProcessCharacterRef(CharacterRef characterData)
    {
        List<Character> characterList = new List<Character>();

        /*foreach (CharacterRef charcterref in characterData.CH)
        {
            Character character = new Character(charcterref.characterId, charcterref.characterName, charcterref.description, charcterref.characterHealth, charcterref.characterAtk, charcterref.characterSpeed);
            characterList.Add(character);
        }*/
    }
}
