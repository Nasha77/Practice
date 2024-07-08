using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Game
{
    private static Character mainCharacter;

    private static List<character> characterList; //access to charcter class list stored here gamestaticclaass
    private static List<Weapon> weaponList; //access to weapon class list stored here gamestaticclaass

    public static Character GetCharacter() //get and set player
    {
        return mainCharacter;
    }

    public static void SetCharacter(Character character) //get and set player
    {
        mainCharacter = character;
    }

    public static List<character> GetCharacterList()
    {
    return characterList; 

    }
    public static void SetCharacterList(List<Character> aList)
    {
       
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
