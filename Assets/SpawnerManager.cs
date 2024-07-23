using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{

    //set timer to spawn enemies
    public float spawnTimer = 0;
    // set the interval for enemies to spawn
    public float spawnInterval = 5;
    // a way to ref which wave its now
    private int waveIndex = 0;
    // current wave
    private int currentWaveIndex = 0;

    // by default havent added yet
    bool enemyAddedToList = false;

    public Transform playerPos;

    List<WaveSpawnerRef> waveList = Game.GetWaveList();
    //List<Enemy> enemies = Game.GetEnemyList();

    // only declaring the "container", not the "content"
    public Dictionary<string, List<GameObject>> ePrefabPool = new Dictionary<string, List<GameObject>>();
    public Dictionary<string, GameObject> ePrefab = new Dictionary<string, GameObject>();

    private void Start()
    {
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

    //private void SpawnEnemy(string enemyId)
    //{
    //    if (ePrefabPool.TryGetValue(enemyId, out GameObject prefab))
    //    {
    //        //spawn close to player target
    //        Vector2 spawnOffset = Random.insideUnitCircle * 3f;
    //        Vector2 spawnPosition = (Vector2)playerPos.position + spawnOffset;
    //    }
    //}

    private void Update()
    {
        if(enemyAddedToList == false)
        {
            return;
        }

        // check if its the right time to spawn AND its the same wave. spawn the enemies
        if (spawnTimer < 0 && currentWaveIndex == waveIndex)
        {
            // checking for matching ids
            Enemy enemyToSpawn = Game.GetEnemyByRefId(waveList[currentWaveIndex].enemyId);

            //random position
            // replace line 22 with getting enemy from wave list so like Game.getwavelist
            //WaveSpawnerRef waves = waveList.
            //Enemy randomEnemy = enemies[Random.Range(0, enemies.Count)]; // u dont want random, change to make it specific
            //Enemy randomEnemy = enemies[ enemies.Count];

            ////Enemy setEnemy = Game.GetEnemyByRefId(waveList[waveIndex].enemyId);
            ///
            // I DOnT THINK THIS IS USED SO CAN DELETE LATER
            Enemy setEnemy = Game.GetEnemyByRefId(waveList[waveIndex].enemyId);

            for (int i = 0; i < waveList[waveIndex].enemyCount; i++)
            {

                Vector2 randomPos = new Vector2(Random.Range(-11.50f, -7.45f), Random.Range(6.70f, 5.18f));
                //GameObject enemyObj = Instantiate(eObj, randomPos, Quaternion.identity) as GameObject;
                //enemyObj.GetComponent<EnemyManager>().SetupHealth(setEnemy);
                waveIndex++;
            }

            // spawn the current wave's enemy at the right interval
            StartCoroutine(SpawnEnemyInterval(enemyToSpawn, waveList[currentWaveIndex].enemyCount));
            waveIndex++;
            // how to spawn wave. can do by interval, like after 30 sec spawn another wave


            // resource.load, theres a demo for this. use addressables
            // enemy class, put a var for each enemy - name of the prefab

            // eobj = replace with addressables
            // later try using addressables

            spawnTimer += spawnInterval;

            // which wave it is, which enemy? 
            // u need get enemy from wave lsit, try to fix line 22 and 30

        }
        // check wave list
        //Debug.Log(Game.GetWaveList().Count);

        spawnTimer -= Time.deltaTime;
    }

    private IEnumerator SpawnEnemyInterval(Enemy enemyToSpawn, int enemiesLeftToSpawn)
    {
        Debug.Log("SPAWNING");
        Vector2 randomPos = new Vector2(Random.Range(-11.50f, -7.45f), Random.Range(6.70f, 5.18f));

        GameObject enemyObj = GetEnemyPrefab(enemyToSpawn.enemyId);
        enemyObj.name = enemyToSpawn.enemyName;
        enemyObj.transform.position = randomPos;


        // assign health to enemies that will be spawned
        enemyObj.GetComponent<EnemyManager>().SetupHealth(enemyToSpawn);
        // GetPlayerObj
        enemyObj.GetComponent<EnemyAI>().SetupEnemy(FindObjectOfType<PlayerManager>().gameObject);
        yield return new WaitForSeconds(5);

        if (enemiesLeftToSpawn > 0)
        {
            StartCoroutine(SpawnEnemyInterval(enemyToSpawn, --enemiesLeftToSpawn));
        }
        else if (enemiesLeftToSpawn == 0)
        {
            currentWaveIndex++;
        }
    }

    private GameObject GetEnemyPrefab(string enemyId)
    {
        GameObject enemyObj;
        if (ePrefabPool.ContainsKey(enemyId) && ePrefabPool[enemyId].Count > 0)
        {
            enemyObj = ePrefabPool[enemyId][0];
            ePrefabPool[enemyId].Remove(enemyObj);
            enemyObj.SetActive(true);
        }
        else
        {
            List<GameObject> enemyObjs = new List<GameObject>();
            ePrefabPool[enemyId] = enemyObjs;
            enemyObj = Instantiate(ePrefab[enemyId]);
        }
        return enemyObj;
    }

    public void ReturnEnemyPrefab(GameObject enemyObj)
    {
        ePrefabPool[enemyObj.name].Add(enemyObj);
        enemyObj.SetActive(false);
    }
}
