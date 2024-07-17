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
    private static List<Enemy> enemyList;
    private static List<WaveSpawnerRef> waveList;
    private static List<Sprite> sprite;
    private static List<DialogueRef> dialogueList;

    //GETSETPLAYER
    public static Player GetPlayer() //get and set player
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
        return sprite;
    }

    public static void SetSpriteList(List<Sprite> aList) // Get and set list for sprite
    {
        sprite = aList;
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


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
