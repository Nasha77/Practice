using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // set how powerful enemy is
    public float damage = 1;

    //enemy current health
    private float curHp;

    //set timer to spawn enemies
    public float spawnTimer;
    public float spawnInterval = 5;

    private void Update()
    {

        if(spawnTimer < 0)
        {
            List<Enemy> enemies = Game.GetEnemyList();
            
            //random position
            Enemy randomEnemy = enemies[Random.Range(0,enemies.Count)];
            Vector2 randomPos = new Vector2(Random.Range(-11.50f, -7.45f), Random.Range(6.70f, 5.18f));

            GameObject enemyObj = Instantiate(eObj, randomPos, Quaternion.identity) as GameObject;
            enemyObj.GetComponent<EnemyManager>().SetupHealth(randomEnemy);

            spawnTimer += spawnInterval;
                
        }

        spawnTimer -= Time.deltaTime;
    }

    // setting current health of enemy using 

    public void SetupHealth(Enemy enemyRef)
    {
        // get total health of an enemy in ENEMY and pass into curHp
        curHp = enemyRef.enemyHealth;
        gameObject.name = "Enemy" + enemyRef.enemyId;
    }
   

    public void MinusHealth(float dmg)
    {
        // curHp - dmg = curHp
        curHp -= dmg;

        // if enemy hp less than or equal 0
        if(curHp <= 0)
        {
            // set health to 0 and destroy gameobj
            curHp = 0;
            Defeated();
        }
    }


    // once health is less than or equal 0, destroy enemy gameobj
    public void Defeated()
    {
        Destroy(gameObject);
    }

   


    // check if weapon collides with the right enemy and then deduct health correctly.
    private void OnTriggerEnter2D(Collider2D other)
    {



        //PLAYER
        if (other.tag == "Player")
        {
            //deal dmg to player
            //Player player = other.GetComponent<Player>();
            Player player = Game.GetPlayer();

            if (player != null)
            {
                Debug.Log("HEALTH" + (player.playerHealth -= damage));
                player.playerHealth -= damage;
            }
        }











        
    }



}


