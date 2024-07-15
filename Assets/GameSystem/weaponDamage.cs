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

    // check if weapon collides with the right enemy and then deduct health correctly.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // makes sure its not other tags
        if(other.tag == "Enemy")
        {


            //get access to enemy health from Game
            Enemy enemy = Game.GetEnemyByRefId("");


           
            
                // check if the enemy is an enemy from the id
                if (enemy != null)
                {
                    //decrease health of the enemy
                   // enemy.enemyHealth -= damage;
                }
            

            
        }
    }
}
