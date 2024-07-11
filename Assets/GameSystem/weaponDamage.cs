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
            //weapon deal dmg to enemy
            Enemy enemy = Game.GetEnemyList()[0];

            if(enemy != null ) {
                //enemy.enemyHealth -= damage;
            }
        }
    }
}
