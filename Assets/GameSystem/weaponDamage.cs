// KEE POH KUN

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponDamage : MonoBehaviour
{
    // weapon's atk
    public float weaponDmg;

    // character's atk dmg
    public float characterDmg, damage;

    public Collider2D weaponCollider;

    // list to hold all weepons
   public List<Weapon> weaponList;

    //EnemyManager ref
    public EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        // get character atk and assign it to  chaarcterdmg
        characterDmg = Game.GetPlayer().GetCharacterAtk();

        // retreive list of all weapons
        weaponList = Game.GetWeaponList();



        // since character stores weaponID, ask the game to find the weapon by the player's stored weaponID. and then take the weapon's atk value
        // weaponID ( Player's current weapon ). weapon attack
        // Retrieve the attack value of the player's current weapon and assign it to weaponDmg
        weaponDmg = Game.GetWeaponByRefId(Game.GetPlayer().GetCurrentCharacterWeapon()).weaponATK;

    }

 
   


    // check if weapon collides with the right enemy and then deduct health correctly.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ensure that the collided object has the "Enemy" tag
        if (other.tag == "Enemy")
        {
            // Calculate the total damage combining weapon and character attack
            damage = weaponDmg + characterDmg;

            // deduct dmg from damage above from enemy's health
            other.gameObject.GetComponent<EnemyManager>().MinusHealth(damage);
          

          

        }
        }
    }
