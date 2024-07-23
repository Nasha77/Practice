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
        /////////////////////////PLEASE FIX THIS LATERRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR///////////////////////////////
       // weaponDmg = Game.GetPlayer().SetCurrentCharacterWeapon(weaponList[].weaponATK);

        // set total dmg at the start
        Debug.Log(damage);

    }

    // Update is called once per frame
    void Update()
    {
        
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
            //EnemyManager enemy = GetComponent<EnemyManager>();
            //Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"+ enemy);


            damage = weaponDmg + characterDmg;
            other.gameObject.GetComponent<EnemyManager>().MinusHealth(damage);
          

            //// check if there is an enemy
            //if (enemy1 != null || enemy2 != null)
            //{
            //    // check for enemy1

            //    Debug.Log("ENEMYDIES" + (enemy1.enemyHealth -= damage));
            //    //decrease health of the enemy
            //    enemy1.enemyHealth -= damage;

            //    if (enemy1.enemyHealth < 0 || enemy2.enemyHealth < 0)
            //    {
            //        spawnerManager.ReturnEnemyPrefab();
            //    }
            //}

            //if (enemy1 != null || enemy2 != null)
            //{
            //    //check for enemy2
            //    Debug.Log("ENEMYDIES" + (enemy2.enemyHealth -= damage));
            //    //decrease health of the enemy
            //    enemy2.enemyHealth -= damage;

            //    if (enemy1.enemyHealth < 0 || enemy2.enemyHealth < 0)
            //    {
            //        spawnerManager.ReturnEnemyPrefab();
            //    }
            //}



        }
        }
    }
