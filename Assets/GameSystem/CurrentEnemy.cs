using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentEnemy
{
    private string id;
    private string curEnemy; // current character states based on character selected 
   

    // character stats based on current character and weapon updates when needed 
    public float enemyHealth;
    public float enemyAtk;
    public float enemySpd;

    private bool statDirty; // when the values in id and current character change then the playermaxhp, player atk and player spd changes

    public CurrentEnemy(string id, string currentEnemy)
    {
        this.id = id;
        this.curEnemy = currentEnemy;
      
        statDirty = true; // if this is true then recalculate
    }

    public string GetId()
    {
        return id;
    }

    public string GetCurrentEnemy() // get function
    {
        return curEnemy;
    }

    public void SetCurrentEnemy(string enemy) // set function
    {
        curEnemy = enemy;
        statDirty = true; // every time player has a new character recalculate
    }


    public bool UpdateStats() // updating data from excel
    {
        if (!statDirty) return false; // if it has not been changed then don't update stats


        Debug.Log("ENEMYUpdateStats " + curEnemy);
        Enemy currentEnemy = Game.GetEnemyByRefId(curEnemy);

        enemyHealth = currentEnemy.enemyHealth;
        enemyAtk = currentEnemy.enemyAtk;
        enemySpd = currentEnemy.enemySpeed;



        statDirty = false; // calculated, no need to calculate again

        return true; // return true when stats are updated
    }



    public float GetEnemyHealth() // check if the health updates if it has not been changed no need to calculate if it has then calculate
    {
        UpdateStats();
        return enemyHealth;
    }

    public float GetEnemyAtk()
    {
        UpdateStats();
        return enemyAtk;
    }

    public float GetEnemySpeed()
    {
        UpdateStats();
        return enemySpd;
    }
}


