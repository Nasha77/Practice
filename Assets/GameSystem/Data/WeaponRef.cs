// Nasha
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //show in inspector
public class WeaponRef //stores feilds that match the the excel/json file
{
    public string weaponID;
    public string characterId;
    public string weaponName;
    public int weaponATK;
    public string description;
    public string weaponSprite;


    // Nested class to store a list of WeaponRef objects.
    public class WeaponDataList
    {
        public List<WeaponRef> weaponRef; // List of WeaponRef objects.
    }
}
