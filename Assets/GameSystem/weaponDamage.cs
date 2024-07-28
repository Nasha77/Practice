// KEE POH KUN

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponDamage : MonoBehaviour
{
    // weapon's atk
    public float weaponDmg;

    public float characterDmg, damage;

    public Collider2D weaponCollider;

   public List<Weapon> weaponList;

    public EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        // get character atk = dmg
        characterDmg = Game.GetPlayer().GetCharacterAtk();

        weaponList = Game.GetWeaponList();


        // Game.GetPlayer().SetCurrentCharacterWeapon(Game.GetWeaponList()[characterIndex].weaponID);


        // since character stores weaponID, ask the game to find the weapon by the player's stored weaponID. and then take the weapon's atk value
        // weaponID ( Player's current weapon ). weapon attack
        weaponDmg = Game.GetWeaponByRefId(Game.GetPlayer().GetCurrentCharacterWeapon()).weaponATK;

        // set total dmg at the start
        Debug.Log(damage);

    }

   


    //// check if weapon collides with the right enemy and then deduct health correctly.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // makes sure its not other tags
        if (other.tag == "Enemy")
        {
            //Enemy enem = other.GetComponent<Enemy>();

            Debug.Log("weapon hit ");
            // check if the enemy is an enemy from the id
           


            damage = weaponDmg + characterDmg;
            other.gameObject.GetComponent<EnemyManager>().MinusHealth(damage);
         



        }
        }
    }
