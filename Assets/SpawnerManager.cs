using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{

    //set timer to spawn enemies
    public float spawnTimer;
    public float spawnInterval = 5;

    // move this to spawner script
    private void Update()
    {

        if (spawnTimer < 0)
        {
            List<WaveSpawnerRef> waveList = Game.GetWaveList();
            List<Enemy> enemies = Game.GetEnemyList();

            //random position
            // replace line 22 with getting enemy from wave list so like Game.getwavelist
            Enemy randomEnemy = enemies[Random.Range(0, enemies.Count)]; // u dont want random, change to make it specific
            // how to spawn wave. can do by interval, like after 30 sec spawn another wave
            Vector2 randomPos = new Vector2(Random.Range(-11.50f, -7.45f), Random.Range(6.70f, 5.18f));

            // resource.load, theres a demo for this. use addressables
            // enemy class, put a var for each enemy - name of the prefab

            // eobj = replace with addressables
            // later try using addressables
            //GameObject enemyObj = Instantiate(eObj, randomPos, Quaternion.identity) as GameObject;
            //enemyObj.GetComponent<EnemyManager>().SetupHealth(randomEnemy);

            spawnTimer += spawnInterval;

            // which wave it is, which enemy? 
            // u need get enemy from wave lsit, try to fix line 22 and 30

        }
        // check wave list
        //  Debug.Log(Game.GetWaveList().Count);

        spawnTimer -= Time.deltaTime;
    }
}
