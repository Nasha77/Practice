using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private string id;
    private string currentCharacter; // current character states based on character selected 
    private string currentCharacterWeapon; // might be WRONG just in case for future refs

    // character stats based on current character and weapon updates when needed 
    public float playerHealth;
    public float playerAtk;
    public float playerSpd;

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


        Debug.Log("UpdateStats " + currentCharacter);
        Character playerCharacter = Game.GetCharacterByRefId(currentCharacter);

        playerHealth = playerCharacter.characterHealth;
        playerAtk = playerCharacter.characterAtk;
        playerSpd = playerCharacter.characterSpeed;

        

        statDirty = false; // calculated, no need to calculate again

        return true; // return true when stats are updated
    }

   


    // New Health property
    //public float Health
    //{
    //    get { return playerHealth; }
    //    set
    //    {
    //        playerHealth = value;
    //        if (playerHealth <= 0)
    //        {
    //            // Handle player defeat, e.g., respawn, game over, etc.
    //            Debug.Log("Player defeated!");
    //        }
    //    }
    //}

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


