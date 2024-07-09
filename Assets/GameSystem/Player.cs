using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private string id;
    private string currentCharacter; //current charcter states based on character has selected 
    private string currentCharacterWeapon;   // might be WRONG just in case for future refs

    //charcter stats based on current character and weapon updates when needed 
    private int playerHealth;
    private float playerAtk;
    private float playerSpd;

    private bool statDirty; //when the vaules in id and current character chnage then the playermaxhp, player atk and player spd chnages


    public Player(string id, string currentCharacter, string currentCharacterWeapon)
    {
        this.id = id;
        this.currentCharacter = currentCharacter;
        this.currentCharacterWeapon = currentCharacterWeapon;

        statDirty = true; //if these is true then recalculate 
    }

    public string GetId()
    {
        return id;
    }

    public string GetCurrentCharacter() //get funtion
    {
        return currentCharacter;    

    }

    public void SetCurrentCharacter(string charcater) //set funtion
    {
        currentCharacter = charcater;

        statDirty = true; //everytime payer have  new character recalculates
    }

    public string GetCurrentCharacterWeapon() //get funtion
    {
        return currentCharacterWeapon;

    }

    public void SetCurrentCharacterWeapon(string weapon) //set funtion
    {
        currentCharacterWeapon = weapon;

        statDirty = true; //everytime payer have  new weapon recalculates
    }

   /* public bool UpdateStats()  TO BE CONTINUEDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD
    {
        if (!statDirty) return false; //if have not been chnaged then dont update stats

        Debug.Log("CALCULATE STATS");

        Character playerCharacter = Game.GetCharacterByRefId(currentCharacter);

        playerHealth = playerCharacter.characterHealth;
        playerAtk = playerCharacter.characterAtk;
        playerSpd = playerCharacter.characterSpeed;

        statDirty = false; //calculated no need to calculate again

    }

    public float GetcharacterHealth() //check if the health updates if it has not been chnaged no need to calculate if it have then calculate
    {
        UpdateStats();
        return playerHealth;
    }

    public float GetcharacterAtk()
    {
        UpdateStats();
        return playerAtk;
    }

    public float GetcharacterSpeed()
    {
        UpdateStats();
        return playerSpd;
    }
   */
}
