using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
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
            //deal dmg to enemy
            Enemy enemy = other.GetComponent<Enemy>();

            if(enemy != null ) {
                enemy.Health -= damage;
            }
        }
    }
}
