using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // set how powerful eenmy is
    public float damage = 1;

    public float Health
    {
        set
        {
            health = value;
            if(health <= 0)
            {
                Defeated();
            }
        }

        get { 
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
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                //player.Health -= damage; 
            }
        }
    }

}
