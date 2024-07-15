using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public string enemyId { get; }
    public string enemyName { get; }
    public int enemyHealth { get; private set; } // Change to private setter
    public int enemyAtk { get; }
    public int enemySpeed { get; }
    public int enemyEXP { get; }

    public Enemy(string enemyId, string enemyName, int enemyHealth, int enemyAtk, int enemySpeed, int enemyEXP)
    {
        this.enemyId = enemyId;
        this.enemyName = enemyName;
        this.enemyHealth = enemyHealth;
        this.enemyAtk = enemyAtk;
        this.enemySpeed = enemySpeed;
        this.enemyEXP = enemyEXP;
    }

    // Method to reduce health
    public void TakeDamage(float damage)
    {
        enemyHealth -= (int)damage;
        Debug.Log($"Enemy {enemyName} took {damage} damage, remaining health: {enemyHealth}");
        if (enemyHealth <= 0)
        {
            Defeated();
        }
    }

    // Method to handle enemy defeat
    private void Defeated()
    {
        Debug.Log($"Enemy {enemyName} defeated.");
        // Add your defeat logic here (e.g., destroy the enemy object)
    }
}

