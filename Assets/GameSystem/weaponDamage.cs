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

    // once health is less than or equal 0, destroy enemy gameobj
    public void Defeated()
    {
        // assign enemy health to 0
        
    }


    //// check if weapon collides with the right enemy and then deduct health correctly.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // makes sure its not other tags
        if (other.tag == "Enemy")
        {
            //Enemy enem = other.GetComponent<Enemy>();

            Debug.Log("TOUCHYTOUCHY");
            // check if the enemy is an enemy from the id
            //why is this null??
            Enemy enemy1 = Game.GetEnemyByRefId("e101");
            Enemy enemy2 = Game.GetEnemyByRefId("e201");


            if(enemy1 == null || enemy2 == null)
            {
                Debug.Log("BRUH MOMENTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT");
            }

            // check if there is an enemy
            if (enemy1 != null || enemy2 != null)
            {
                // check for enemy1

                Debug.Log("ENEMYDIES" + (enemy1.enemyHealth -= damage));
                //decrease health of the enemy
                enemy1.enemyHealth -= damage;

                if (enemy1.enemyHealth < 0 || enemy2.enemyHealth < 0)
                {
                    Defeated();
                }
            }

            if (enemy1 != null || enemy2 != null)
            {
                //check for enemy2
                Debug.Log("ENEMYDIES" + (enemy2.enemyHealth -= damage));
                //decrease health of the enemy
                enemy2.enemyHealth -= damage;

                if (enemy1.enemyHealth < 0 || enemy2.enemyHealth < 0)
                {
                    Defeated();
                }
            }



        }
        }
    }
