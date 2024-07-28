using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
   
    public string enemyId { get; set; }
    public string enemyName { get; set; }
    public float enemyHealth { get; set; }
    public int enemyAtk { get; set; }
    public int enemySpeed { get; set; }

    
   


    public Enemy(string enemyId, string enemyName, float enemyHealth, int enemyAtk, int enemySpeed)
    {
        this.enemyId = enemyId;
        this.enemyName = enemyName;
        this.enemyHealth = enemyHealth;
        this.enemyAtk = enemyAtk;
        this.enemySpeed = enemySpeed;
        
      
    }


   
}
