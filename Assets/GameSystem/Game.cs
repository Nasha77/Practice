using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Game
{
    private static Player mainPlayer;

    private static List<Character> characterList; //access to charcter class list stored here gamestaticclaass
    private static List<Weapon> weaponList; //access to weapon class list stored here gamestaticclaass

    public static Player GetPlayer() //get and set player
    {
        return mainPlayer;
    }

    public static void SetPlayer(Player player) //get and set player
    {
        mainPlayer = player;
    }

    public static List<Character> GetCharacterList() //get and set charcter list jush and cara
    {
    return characterList; 

    }
    public static void SetCharacterList(List<Character> aList) //get and set charcter list jush and cara
    {
        characterList = aList;
    }

    public static Character GetCharacterByRefId(string id) //getting one single avatar using its ref id
    {
        return characterList.Find(x => x.characterId == id);
    }

    public static List<Weapon> GetWeaponList() //get and set list for weapon
    {
        return weaponList;
    }

    public static void SetWeaponList(List<Weapon> aList) //get and set list for weapon
    {
        weaponList = aList; 
    }

   public static Weapon GeWeaponByRefId(string id) //getting one single WEAPON using its ref id
    {
        return weaponList.Find(x => x.weaponID == id);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
