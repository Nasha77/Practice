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
            Debug.Log("Weapon collided with enemy.");
            // Get access to enemy health from Game
            Enemy enemy = Game.GetEnemyByRefId(""); // Add proper ID if needed

            List<Enemy> enemyList = Game.GetEnemyList();

            // Iterate through each enemy in the enemy list and check if it's the right enemy, then reduce health
            foreach (Enemy id in enemyList)
            {
                // Check if the enemy is an enemy from the ID
                if (id != null && id == enemy)
                {
                    Debug.Log($"Applying damage to enemy {id.enemyName}.");
                    // Decrease health of the enemy
                    id.TakeDamage(damage);
                }
            }
        }
    }
}
