using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public string weaponID { get; }
    public string characterId { get; }
    public string weaponName { get; }
    public int weaponATK { get; }
    public string description { get; }

    public string weaponSprite { get; }

    public Weapon(string weaponID, string characterId, string weaponName, int weaponATK, string description, string weaponSprite)
    {
        this.weaponID = weaponID;
        this.characterId = characterId;
        this.weaponName = weaponName;
        this.weaponATK = weaponATK;
        this.description = description;
        this.weaponSprite = weaponSprite;
    }
}
