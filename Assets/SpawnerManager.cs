using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{

    //set timer to spawn enemies
    public float spawnTimer = 0;
    // set the interval for enemies to spawn
    public float spawnInterval = 2;
    // a way to ref which wave its now
    public int waveIndex = 0;
    // current wave
    public int currentWaveIndex = 0;

    // by default havent added yet
    bool enemyAddedToList = false;

    public PlayerManager playerManager;

    public Transform playerPos;

    List<WaveSpawnerRef> waveList = Game.GetWaveList();
    //List<Enemy> enemies = Game.GetEnemyList();

    // only declaring the "container", not the "content"
    public Dictionary<string, List<GameObject>> ePrefabPool = new Dictionary<string, List<GameObject>>();
    public Dictionary<string, GameObject> ePrefab = new Dictionary<string, GameObject>();

    private void Start()
    {
        // this is causing the extra enemy to be spawned, cuz everytime u start the game, spawning will be true and one will spawn
       EnemySetUp();
    }

    private void EnemySetUp()
    {
        //// declaring content for the container
        //List<GameObject> enemyObjs = new List<GameObject>();

        // adding the prefab into the list you created above
        ePrefab.Add("e101", AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/FanEnemies/e101.prefab"));
        ePrefab.Add("e201", AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/FanEnemies/e201.prefab"));
        ePrefab.Add("e301", AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/FanEnemies/e301.prefab"));

        //// putting a prefab into the list
        //ePrefabPool["e101"] = enemyObjs;

        //// 
        //ePrefabPool["e101"][0].SetActive(false);

        // if you want add enemy, set to true
        enemyAddedToList = true;
    }

   

    private void Update()
    {


        if (enemyAddedToList == false)
        {
            return;
        }

        spawnTimer -= Time.deltaTime;

        // will run code below if enemyaddedtolist is true
        // code below only runs when its the next wave
        // check if its the right time to spawn AND its the same wave. spawn the enemies
        if (spawnTimer < 0 && currentWaveIndex == waveIndex)
        {
            

            // checking for matching ids
            Enemy enemyToSpawn = Game.GetEnemyByRefId(waveList[currentWaveIndex].enemyId);

            Debug.Log("NEXT WAVE------------------");

            //random position
            // replace line 22 with getting enemy from wave list so like Game.getwavelist
            //WaveSpawnerRef waves = waveList.
            //Enemy randomEnemy = enemies[Random.Range(0, enemies.Count)]; // u dont want random, change to make it specific
            //Enemy randomEnemy = enemies[ enemies.Count];


            ////Enemy setEnemy = Game.GetEnemyByRefId(waveList[waveIndex].enemyId);



            ///
            // I DOnT THINK THIS IS USED SO CAN DELETE LATER

            //Enemy setEnemy = Game.GetEnemyByRefId(waveList[waveIndex].enemyId);

            // for each enemy, spawn it at the location 
            //for(int i = 0; i < waveList[waveIndex].enemyCount; i++)
            //{

            //    Vector2 randomPos = new Vector2(Random.Range(-11.50f, -7.45f), Random.Range(6.70f, 5.18f));
            //    //GameObject enemyObj = Instantiate(eObj, randomPos, Quaternion.identity) as GameObject;
            //    //enemyObj.GetComponent<EnemyManager>().SetupHealth(setEnemy);
            //    waveIndex++;
            //}




            // spawn the current wave's enemy and its amount one by one at the right interval
            // -1 the count cuz at the start it alr spawn one time. so if u -1, it will spawn the right amount
            StartCoroutine(SpawnEnemyInterval(enemyToSpawn, waveList[currentWaveIndex].enemyCount-1));
            waveIndex++;

            Debug.Log("current wave is at" + currentWaveIndex);
            // how to spawn wave. can do by interval, like after 30 sec spawn another wave


            // resource.load, theres a demo for this. use addressables
            // enemy class, put a var for each enemy - name of the prefab

            // eobj = replace with addressables
            // later try using addressables

            spawnTimer += spawnInterval;

            
        }
        // check wave list
        //Debug.Log("EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" + Game.GetWaveList().Count);

       
    }

    // this code here might be the problem
    private IEnumerator SpawnEnemyInterval(Enemy enemyToSpawn, int enemiesLeftToSpawn)
    {
       

       
        Vector2 randomPos = new Vector2(Random.Range(-11.50f, -7.45f), Random.Range(6.70f, 5.18f));

        // spawn the desired enemy at a position 
        GameObject enemyObj = GetEnemyPrefab(enemyToSpawn.enemyId);
        enemyObj.name = enemyToSpawn.enemyId;
        enemyObj.transform.position = randomPos;


        // assign health and atk to enemies that will be spawned
        enemyObj.GetComponent<EnemyManager>().SetupEnemy(enemyToSpawn, this, FindObjectOfType<PlayerManager>().gameObject);
       
        // GetPlayerObj
        //enemyObj.GetComponent<EnemyAI>().SetupEnemy(FindObjectOfType<PlayerManager>().gameObject);
        yield return new WaitForSeconds(5);


        // if theres enemies left to spawn, continue spawning
        if (enemiesLeftToSpawn > 0)
        {
            Debug.Log("enemies left" +enemiesLeftToSpawn);
            StartCoroutine(SpawnEnemyInterval(enemyToSpawn, --enemiesLeftToSpawn));
        }

        // if no more left to spawn, go next wave
        else if (enemiesLeftToSpawn == 0)
        {
            Debug.Log("increased wave index!!!!!!");
            currentWaveIndex++;

        }

    }

    private GameObject GetEnemyPrefab(string enemyId)
    {
        GameObject enemyObj;

        // if obj exists in the pool AND if theres enough obj in the pool to be used
        if (ePrefabPool.ContainsKey(enemyId) && ePrefabPool[enemyId].Count > 0)
        {
            // set obj as the first one
            enemyObj = ePrefabPool[enemyId][0];

            //remove it to be used
            ePrefabPool[enemyId].Remove(enemyObj);

            // set gameObj to be active 
            enemyObj.SetActive(true);
        }

        // if obj doesnt exist in pool and not enough
        else
        {
            // create new list
            List<GameObject> enemyObjs = new List<GameObject>();

            //use the new list instead
            ePrefabPool[enemyId] = enemyObjs;

            //
            enemyObj = Instantiate(ePrefab[enemyId]);
        }
        return enemyObj;
    }

    public void ReturnEnemyPrefab(GameObject enemyObj)
    {
        // checking if pool exists
        // check if key doesnt exist, then add pool in
        if (!ePrefabPool.ContainsKey(enemyObj.name))
        {
            // add in the new empty pool
            ePrefabPool.Add(enemyObj.name, new List<GameObject>());
        }

        // if key exists,
        // adding obj to pool
        ePrefabPool[enemyObj.name].Add(enemyObj);
        enemyObj.SetActive(false);
    }










    //private void SpawnEnemy(string enemyId)
    //{
    //    if (ePrefabPool.TryGetValue(enemyId, out GameObject prefab))
    //    {
    //        //spawn close to player target
    //        Vector2 spawnOffset = Random.insideUnitCircle * 3f;
    //        Vector2 spawnPosition = (Vector2)playerPos.position + spawnOffset;
    //    }
    //}

}
