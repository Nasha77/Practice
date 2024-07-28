//Nasha
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Character class is the character in the game.
public class Character
{
    // Character ID, a unique identifier for the character.
    // Used to retrieve character data from the CharacterDatabase.
    // GET: gets the character's unique ID.
    public string characterId { get; }

    // GET: gets the character's name.
    public string characterName { get; }

    // GET: gets the character's description.
    public string description { get; }

    // GET: gets the character's current health points.
    public int characterHealth { get; }

    // GET: gets the character's attack power.
    public int characterAtk { get; }

    // GET: gets the character's speed.
    public int characterSpeed { get; }

    // GET: gets the character's sprite image.
    public string characterSprite { get; }

    // Constructor to create a new Character instance.
    // Called when the game loads character data from the CharacterDatabase.
    // Initializes the character's properties with the provided values.
    public Character (string characterId, string characterName, string description, int characterHealth, int characterAtk, int characterSpeed, string characterSprite)
    {
        // Sets the character's ID, name, description, health, attack, speed, and sprite.
        this.characterId = characterId;
        this.characterName = characterName;
        this.description = description;
        this.characterHealth = characterHealth;
        this.characterAtk = characterAtk;
        this.characterSpeed = characterSpeed;
        this.characterSprite = characterSprite;
       
    }


}
