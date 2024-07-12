using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponDamage : MonoBehaviour
{
    // weapon's atk
    public float damage = 3;

    public Collider2D weaponCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {


            //get access to enemy health from Game
            //Enemy enemy = Game.Ge

            List<Enemy> enemyList = Game.GetEnemyList();

            // reiterate through each enemy in enemy list and check if its the right enemy, then reduce health 
            foreach (Enemy id in enemyList)
            {
                // check if the enemy is an enemy from the id
                if (enemy != null)
                {
                    //decrease health of the enemy
                    //enemy.enemyHealth -= damage;
                }
            }

            
        }
    }
}
