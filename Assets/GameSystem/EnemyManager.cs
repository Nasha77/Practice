using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // set how powerful enemy is
    public float damage = 1;


    public float Health
    {
        set
        {
            health = value;
            if (health <= 0)
            {
                // enemy dies
                Defeated();
            }
        }

        get
        {
            return health;
        }
    }
    public float health = 1;



    // once health is less than or equal 0, destroy enemy gameobj
    public void Defeated()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //deal dmg to player
            //Player player = other.GetComponent<Player>();
            Player player = Game.GetPlayer();

            if (player != null)
            {
                Debug.Log("HEALTH" + (player.Health -= damage));
                player.Health -= damage;
            }
        }
    }




}


