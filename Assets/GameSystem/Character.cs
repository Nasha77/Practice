using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string characterId { get; }
    public string characterName { get; }
    public string description { get; }
    public int characterHealth { get; }
    public int characterAtk { get; }
    public int characterSpeed { get; }

    public Character (string characterId, string characterName, string description, int characterHealth, int characterAtk, int characterSpeed)
    {
        this.characterId = characterId;
        this.characterName = characterName;
        this.description = description;
        this.characterHealth = characterHealth;
        this.characterAtk = characterAtk;
        this.characterSpeed = characterSpeed;
    }
}
