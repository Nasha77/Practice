// KEE POH KUN

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerManager : MonoBehaviour
{

    //set timer to spawn enemies
    public float spawnTimer = 0;
    // set the interval for enemies to spawn
    public float spawnInterval = 1;
    // a way to ref which wave its now
    public int waveIndex = 0;
    // current wave
    public int currentWaveIndex = 0;

    // by default havent added yet
    bool enemyAddedToList = false;

    public PlayerManager playerManager;

    public QuestManager questManager;

    public static QuestManager instance;

    public Transform playerPos;

    List<WaveSpawnerRef> waveList = Game.GetWaveList();
  

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
      

        // adding the prefab into the list you created above
        ePrefab.Add("e101", Resources.Load<GameObject>("Prefab/FanEnemies/e101"));
        ePrefab.Add("e201", Resources.Load<GameObject>("Prefab/FanEnemies/e201"));
        ePrefab.Add("e301", Resources.Load<GameObject>("Prefab/FanEnemies/e301"));


        // I want add enemy, so this will be set to true
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
           
            
            Debug.Log($"Selected {enemyToSpawn.enemyName}");
            Debug.Log("NEXT WAVE------------------");
            Debug.Log(waveList[currentWaveIndex].enemyCount - 1);

            // spawn the current wave's enemy and its amount one by one at the right interval
            // -1 the count cuz at the start it alr spawn one time. so if -1 here, it will spawn the right amount
            StartCoroutine(SpawnEnemyInterval(enemyToSpawn, waveList[currentWaveIndex].enemyCount-1));

            
            // increase wave idex
            waveIndex++;

            Debug.Log("current wave is at" + currentWaveIndex);
         
            spawnTimer += spawnInterval;

            
        }

       
    }

    // spawn enemies at a specified interval
    private IEnumerator SpawnEnemyInterval(Enemy enemyToSpawn, int enemiesLeftToSpawn)
    {
       

       // set up the position to be used to spawn enemy
        Vector2 randomPos = new Vector2(Random.Range(-11.50f, 11.50f), Random.Range(-11.70f, 11.18f));

        // spawn the desired enemy at a position 
        GameObject enemyObj = GetEnemyPrefab(enemyToSpawn.enemyId);
        enemyObj.name = enemyToSpawn.enemyId;
        enemyObj.transform.position = randomPos;


        // assign health and atk attributes to enemies that will be spawned
        enemyObj.GetComponent<EnemyManager>().SetupEnemy(enemyToSpawn, this, FindObjectOfType<PlayerManager>().gameObject);
       
        // wait for awhile before spawning again
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

            // Check if all waves are completed
            if (currentWaveIndex >= waveList.Count)
            {
                Debug.Log("All waves completed. Checking if all enemies are defeated...");

                // Check if all enemies are defeated
                StartCoroutine(CheckForWinCondition());
            }

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

            //  notify questManager that an enemy has been killed
            questManager.OnEnemyKilled();

            // set gameObj to be active 
            enemyObj.SetActive(true);
        }

        // if obj doesnt exist in pool and not enough obj
        else
        {
            // create new list
            List<GameObject> enemyObjs = new List<GameObject>();

            //use the new list instead
            ePrefabPool[enemyId] = enemyObjs;

            //  instantiate a new enemy object from the prefab
            enemyObj = Instantiate(ePrefab[enemyId]);
        }

        //return enemy obj
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


    private IEnumerator CheckForWinCondition()
    {
        // Wait for a short duration to ensure all enemy deaths are processed
        yield return new WaitForSeconds(2);

        // Check if there are no active enemies left in the scene
        if (FindObjectsOfType<EnemyManager>().Length == 0)
        {
            Debug.Log("All enemies defeated. You win!");

            // Load the WIN scene
            SceneManager.LoadScene("WIN");
        }
    }

}
