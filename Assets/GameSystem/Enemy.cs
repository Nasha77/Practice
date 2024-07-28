//Nasha
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy class representing an enemy in the game.
public class Enemy
{

    // GET: Gets the enemy's ID.
    // SET: Sets the enemy's ID.
    public string enemyId { get; set; }

    // Enemy name, the name of the enemy.
    // GET: Gets the enemy's name.
    // SET: Sets the enemy's name.
    public string enemyName { get; set; }

    // GET: Gets the enemy's health.
    // SET: Sets the enemy's health.
    public float enemyHealth { get; set; }

    // GET: Gets the enemy's attack power.
    // SET: Sets the enemy's attack power.
    public int enemyAtk { get; set; }

    // GET: Gets the enemy's speed.
    // SET: Sets the enemy's speed.
    public int enemySpeed { get; set; }




    // Constructor to create a new Enemy instance.
    // Called when the game loads enemy data.
    // Initializes the enemy's properties with the provided values.
    public Enemy(string enemyId, string enemyName, float enemyHealth, int enemyAtk, int enemySpeed)
    {

        // Sets the enemy's ID, name, health, attack, and speed.
        this.enemyId = enemyId;
        this.enemyName = enemyName;
        this.enemyHealth = enemyHealth;
        this.enemyAtk = enemyAtk;
        this.enemySpeed = enemySpeed;
        
    }


   
}
