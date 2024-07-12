using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponDamage : MonoBehaviour
{
    // weapon's attack
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
        if (other.tag == "Enemy")
        {
            // get access to enemy health from Game
            Enemy enemy = Game.GetEnemyByRefId("e101");

            // if the enemy is not null and matches the one we are looking for
            if (enemy != null)
            {
                // decrease health of the enemy
                enemy.enemyHealth -= (int)damage;

                // optional: check for enemy death
                if (enemy.enemyHealth <= 0)
                {
                    // handle enemy death (e.g., destroy enemy, award points, etc.)
                }
            }
        }
    }
}

