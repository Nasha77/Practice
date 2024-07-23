using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // set how powerful enemy is
    public float damage = 1;

    //enemy current health
    private float curHp;

    public PlayerManager playerManager;

    public SpawnerManager spawnerManager;

    List<WaveSpawnerRef> waveList = Game.GetWaveList();

    // setting current health of enemy using 


    private void Start()
    {

        // put enemy atk as dmg
       // Enemy dmg = Game.GetEnemyByRefId(waveList[spawnerManager.waveIndex].enemyId);
    }

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
            playerManager.PlayerDeath();
        }
    }


    // once health is less than or equal 0, destroy enemy gameobj
    public void Defeated()
    {
       
        //spawnerManager.ReturnEnemyPrefab();
      
    }

    //set a function to deplete health in enemy and player each, then call it in respective scripts attached to each after checking for tag
   


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
                //Debug.Log("HEALTH" + (player.playerHealth -= damage));
                //player.playerHealth -= damage;

                MinusHealth(100);
            }

            //if(player.playerHealth < 0)
            //{
            //    //KILLS PLAYER
            //    playerManager.PlayerDeath();
            //}
        }







        // change sprite in gameobj
        // or change prefab, use prefab for different characters



        
    }



}


