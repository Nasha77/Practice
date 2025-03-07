// NASHA, KEE POH KUN

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player class, representing the player in the game.
public class Player
{
    // Private variables to store the player's ID, current character, and current character weapon.
    private string id;
    private string currentCharacter; // current character states based on character selected 
    private string currentCharacterWeapon; 

    // character stats based on current character and weapon updates when needed 
    public float playerHealth;
    public float playerAtk;
    public float playerSpd;
    public string characterSprite;
    public string weaponSprite;

    private bool statDirty; // when the values in id and current character change then the playermaxhp, player atk and player spd changes

    public Player(string id, string currentCharacter, string currentCharacterWeapon)
    {
        this.id = id;
        this.currentCharacter = currentCharacter;
        
        this.currentCharacterWeapon = currentCharacterWeapon;


        statDirty = true; // if this is true then recalculate
    }

    public string GetId()
    {
        return id;
    }

    public void SetCurrentId(string idstring)
    {
        id = idstring;
        
    }
    public string GetCurrentCharacter() // get function
    {
        return currentCharacter;
    }

    public void SetCurrentCharacter(string character) // set function
    {
        currentCharacter = character;
        statDirty = true; // every time player has a new character recalculate
    }

    public string GetCurrentCharacterWeapon() // get function
    {
        return currentCharacterWeapon;
    }

    public void SetCurrentCharacterWeapon(string weapon) // set function
    {
        currentCharacterWeapon = weapon;
        statDirty = true; // every time player has a new weapon recalculate
    }

    // you r trying to call something thats not set so confirm will give u null
    // its the way this section is written.
    public bool UpdateStats() // updating data from excel
    {
        if (!statDirty) return false; // if it has not been changed then don't update stats

        // Get the character and weapon data from the Game class.
        Character playerCharacter = Game.GetCharacterByRefId(currentCharacter);
        Weapon playerWeapon = Game.GetWeaponByRefId(currentCharacterWeapon);

        playerHealth = playerCharacter.characterHealth;
        playerAtk = playerCharacter.characterAtk;
        playerSpd = playerCharacter.characterSpeed;
        characterSprite = playerCharacter.characterSprite;
        weaponSprite = playerWeapon.weaponSprite;


        statDirty = false; // calculated, no need to calculate again

        return true; // return true when stats are updated
    }


    // Get methods for the player's stats, which call UpdateStats() to ensure the stats are up to date.

    public float GetCharacterHealth() // check if the health updates if it has not been changed no need to calculate if it has then calculate
    {
        UpdateStats();
        return playerHealth;
    }

    public float GetCharacterAtk()
    {
        UpdateStats();
        return playerAtk;
    }

    public float GetCharacterSpeed()
    {
        UpdateStats();
        return playerSpd;
    }
}


