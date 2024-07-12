using System.Collections.Generic;
using UnityEngine;

public class Game
{
    private static Player mainPlayer;

    private static List<Character> characterList;
    private static List<Weapon> weaponList;
    private static List<Enemy> enemyList;

    // GET/SET Player
    public static Player GetPlayer()
    {
        return mainPlayer;
    }

    public static void SetPlayer(Player player)
    {
        mainPlayer = player;
    }

    // GET/SET Character List
    public static List<Character> GetCharacterList()
    {
        return characterList;
    }

    public static void SetCharacterList(List<Character> aList)
    {
        characterList = aList;
    }

    public static Character GetCharacterByRefId(string id)
    {
        return characterList.Find(x => x.characterId == id);
    }

    // GET/SET Weapon List
    public static List<Weapon> GetWeaponList()
    {
        return weaponList;
    }

    public static void SetWeaponList(List<Weapon> aList)
    {
        weaponList = aList;
    }

    public static Weapon GetWeaponByRefId(string id)
    {
        return weaponList.Find(x => x.weaponID == id);
    }

    // GET/SET Enemy List
    public static List<Enemy> GetEnemyList()
    {
        return enemyList;
    }

    public static void SetEnemyList(List<Enemy> aList)
    {
        enemyList = aList;
    }

    public static Enemy GetEnemyByRefId(string id)
    {
        return enemyList.Find(x => x.enemyId == id);
    }
}

