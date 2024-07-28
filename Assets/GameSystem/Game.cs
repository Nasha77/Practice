// NASHA, KEE POH KUN
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.TextCore.Text;

// This script is the home for managing game data and objects in game.
// It provides a way to access and manipulate various game objects and data by doing Game.(followed by what we want)
// such as players, characters, weapons, enemies, waves, sprites, dialogues, and quests.

public class Game
{
    // Private static variables that store references to game objects and data.
    // shared across all game script, for access and manipulate game data from anywhere in the game.
    private static Player mainPlayer; // Stores a reference to the main player object.
    private static Weapon weapon;


    // Lists of game objects and data, used to store and manage collections of data in the game.
    private static List<Character> characterList; //access to charcter class list stored here gamestaticclaass
    private static List<Weapon> weaponList; //access to weapon class list stored here gamestaticclaass
    private static List<Enemy> enemyList;
    private static List<WaveSpawnerRef> waveList;
    private static List<Sprite> spriteList;
    private static List<DialogueRef> dialogueList;
    private static List<Quest> questList;

    //GETSETPLAYER
    // These methods allow other scripts to access and update the main player object.
    public static Player GetPlayer() //Get and set methods for the main player object.
    {
        return mainPlayer;
    }

    public static void SetPlayer(Player player) //get and set player
    {
        mainPlayer = player;
    }

    //GETSETCHARCATER
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

    //GETSETPWEAPON
    public static Weapon GetWeapon() //get and set player
    {
        return weapon;
    }

    public static List<Weapon> GetWeaponList() //get and set list for weapon
    {
        return weaponList;
    }

    public static void SetWeaponList(List<Weapon> aList) //get and set list for weapon
    {
        weaponList = aList; 
    }

   public static Weapon GetWeaponByRefId(string id) //getting one single WEAPON using its ref id
    {
        return weaponList.Find(x => x.weaponID == id);
    }

    //GETSETPENEMY

    public static List<Enemy> GetEnemyList() //get and set list for enemy
    {
        return enemyList;
    }

    public static void SetEnemyList(List<Enemy> aList) //get and set list for enemy
    {
        enemyList = aList;
    }

    public static Enemy GetEnemyByRefId(string id) //getting one single ENEMY using its ref id
    {
        return enemyList.Find(x => x.enemyId == id);
    }

    //GETSETWAVE

    public static List<WaveSpawnerRef> GetWaveList() // Get and set list for waves
    {
        return waveList;
    }

    public static void SetWaveList(List<WaveSpawnerRef> aList) // Get and set list for waves
    {
        waveList = aList;
    }

    public static WaveSpawnerRef GetWaveByRefId(string id) // Getting one single wave using its ref id
    {
        return waveList.Find(x => x.waveId == id);
    }

    //GETSETSPRITE

    public static List<Sprite> GetSpriteList() // Get and set list for sprite
    {
        return spriteList;
    }

    public static void SetSpriteList(List<Sprite> aList) // Get and set list for sprite
    {
        spriteList = aList;
    }

    //GETSETDIALOUGE
    public static List<DialogueRef> GetDialogueList() // Get and set list for dialogues
    {
        return dialogueList;
    }

    public static void SetDialogueList(List<DialogueRef> aList) // Get and set list for dialogues
    {
        dialogueList = aList;
    }

    public static DialogueRef GetDialogueByRefId(int id) // Getting one single dialogue using its cutsceneRefId
    {
        return dialogueList.Find(x => x.cutsceneRefId == id);
    }

    public static DialogueRef GetDialogueByNextRefId(int id) // Getting one single dialogue using its nextcutsceneRefId
    {
        return dialogueList.Find(x => x.nextcutsceneRefId == id);
    }

    public static DialogueRef GetcutSceneSetID(int id) // Getting one single dialogue using its nextcutsceneRefId
    {
        return dialogueList.Find(x => x.cutSceneSetID == id);
    }

    public static List<Quest> GetQuestList() //get and set list for quest
    {
        return questList;
    }

    public static Quest GetQuestRefById(string id)
    {
        return questList.Find(x => x.questId == id);
    }

    public static void SetQuestList(List<Quest> aList) // Get and set list for quest
    {
        questList = aList;
    }

}
