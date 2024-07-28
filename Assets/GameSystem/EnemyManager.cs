// KEE POH KUN

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // enemy attributes
    //enemy current health
    private float curHp;
    // enemy atk
    public float enemyDmg;

    public float enemySpd;

    public string enemyId;


    public SpawnerManager spawnerManager;

    //public QuestManager questManager;

   

    //List<WaveSpawnerRef> waveList = Game.GetWaveList();

    private GameObject player;

    private float dist;


    

    // Update is called once per frame
    void Update()
    {
        // If the player object is not assigned, return immediately
        if (player == null)
        {
            return;
            
        }

        // Calculate the distance between the enemy and the player
        dist = Vector2.Distance(transform.position, player.transform.position);


        //Vector2 dir = player.transform.position - transform.position;

        // move enemy  towards the player
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemySpd * Time.deltaTime);
    }


    // method to sets up enemy health and atk
    public void SetupEnemy(Enemy enemyRef, SpawnerManager spManager, GameObject player)
    {
        // get total health of an enemy in ENEMY and pass into curHp
        // Set the enemy's health, attack, speed, and Id from the provided enemy reference
        curHp = enemyRef.enemyHealth;
        enemyDmg = enemyRef.enemyAtk;
        enemySpd = enemyRef.enemySpeed;
        enemyId = enemyRef.enemyId;

        // Name the enemy game object based on its Id data
        gameObject.name = "Enemy" + enemyRef.enemyId;

        // Assign the spawner manager and player references
        this.spawnerManager = spManager;
        this.player = player;


    }


    // Method to reduce the enemy's health when damaged
    public void MinusHealth(float dmg)
    {
        // curHp - dmg = curHp
        // deduct damage from the enemy's current health
        curHp -= dmg;

        // if enemy hp less than or equal 0
        if(curHp <= 0)
        {
            // set health to 0 and destroy gameobj
            curHp = 0;      

            // once enemy dies, call the questmanager that enemy has been killed for quest
            // calls func in quest to increase enemy kill count
            spawnerManager.questManager.OnEnemyKilled();

            // Return the enemy prefab to the spawner manager for recycling
            spawnerManager.ReturnEnemyPrefab(this.gameObject);
        }
    }


}


