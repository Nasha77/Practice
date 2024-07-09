using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Wave
{
    // name of the wave
    public string waveName;
    public int enemyNumber;
    public GameObject[] enemyType;
    public float spawnInterval;
}
public class WaveSpawner : MonoBehaviour
{
    public GameObject player;

    // replace this array with the wave list in game class
    //Game. get stuff
    public Wave[] waves;

    // randomly spawn
    public Transform[] spawnPoints;


    // set up new list for enemies
    //public List<Enemies> enemies = new List<Enemies>();
    public Wave currentWave;
    public int currentWaveNumber;

    // used to check if we allow spawn
    private bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        currentWave = waves[currentWaveNumber];
        SpawnWave();
    }

    //spawn specific enemy at random point
    void SpawnWave()
    {
        if(canSpawn)
        {
            // specify the 1st enemy to spawn
            GameObject spawnFirst = currentWave.enemyType[0];

            spawnFirst.GetComponent<EnemyAI>().SetupEnemy(player);

            // sppecif the 2nd enemy to spawn
            GameObject spawnSecond = currentWave.enemyType[1];
            spawnSecond.GetComponent<EnemyAI>().SetupEnemy(player);

            // can use for loop for the above spawn

            // random spawn point
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // spawn one
            Instantiate(spawnFirst, randomPoint.position, Quaternion.identity);

            //spawn 2
            Instantiate(spawnSecond, randomPoint.position, Quaternion.identity);

            // everyloop will decrease by 1, when it reaches 0, bool will be set to false to stop spawning.
            currentWave.enemyNumber--;
            if(currentWave.enemyNumber == 0)
            {
                canSpawn = false;
            }

        }
       

    }

    

}


