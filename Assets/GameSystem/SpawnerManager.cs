// KEE POH KUN

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerManager : MonoBehaviour
{

    //set timer to spawn enemies
    public float spawnTimer = 0;
    // set the interval between enemies to spawn
    public float spawnInterval = 1;
    // a way to ref current wave
    public int waveIndex = 0;
    // keep track of the current wave
    public int currentWaveIndex = 0;

    // by default havent added yet, so set to false
    bool enemyAddedToList = false;

    // ref to playermanager
    public PlayerManager playerManager;

    //ref to questmanager
    public QuestManager questManager;

    // instance of questmanager
    public static QuestManager instance;

    // pos of player
    public Transform playerPos;

    // list of the waves
    List<WaveSpawnerRef> waveList = Game.GetWaveList();


    // this part only declaring the "container", not the "content"

    // Dictionary to pool enemy prefabs
    public Dictionary<string, List<GameObject>> ePrefabPool = new Dictionary<string, List<GameObject>>();
    // Dictionary to store enemy prefab references
    public Dictionary<string, GameObject> ePrefab = new Dictionary<string, GameObject>();

    private void Start()
    {
        // this is causing the extra enemy to be spawned, cuz everytime u start the game, spawning will be true and one will spawn

        // Setup enemy prefabs when the game starts
        EnemySetUp();
    }

    // set up enemy prefabs to be used later
    private void EnemySetUp()
    {
        // declaring content for the "container"
      

        // adding the prefab into the dictionary you created above
        ePrefab.Add("e101", Resources.Load<GameObject>("Prefab/FanEnemies/e101"));
        ePrefab.Add("e201", Resources.Load<GameObject>("Prefab/FanEnemies/e201"));
        ePrefab.Add("e301", Resources.Load<GameObject>("Prefab/FanEnemies/e301"));


        // I want add enemy, so this will be set to true
        enemyAddedToList = true;
    }

   

    private void Update()
    {

        // exit if no enemies are added
        if (enemyAddedToList == false)
        {
            return;
        }

        // decrement spawn timer
        // everytime update runs, timer will start decreasing
        spawnTimer -= Time.deltaTime;

        // will run code below if enemyaddedtolist is true
        // code below only runs when its time to spawn the next wave
        // check if its the right time to spawn AND its the same wave. spawn the enemies
        if (spawnTimer < 0 && currentWaveIndex == waveIndex)
        {


            // Get the enemy to spawn based on the current wave
            Enemy enemyToSpawn = Game.GetEnemyByRefId(waveList[currentWaveIndex].enemyId);
           

            // spawn the current wave's enemy and its amount one by one at the right interval
            // -1 the enemycount cuz at the start it alr spawn one time. so if -1 here, it will spawn the right amount
            StartCoroutine(SpawnEnemyInterval(enemyToSpawn, waveList[currentWaveIndex].enemyCount-1));

            
            // after finish spawning all enemies in current wave, increase wave index
            waveIndex++;
         
            //reset timer for next wave
            spawnTimer += spawnInterval;

            
        }

       
    }

    // coroutine to spawn enemies at a specified interval
    private IEnumerator SpawnEnemyInterval(Enemy enemyToSpawn, int enemiesLeftToSpawn)
    {
       

       // set up the random position to be used to spawn enemy
        Vector2 randomPos = new Vector2(Random.Range(-11.50f, 11.50f), Random.Range(-11.70f, 11.18f));

        // spawn the desired enemy at a position 
        GameObject enemyObj = GetEnemyPrefab(enemyToSpawn.enemyId);
        enemyObj.name = enemyToSpawn.enemyId;
        enemyObj.transform.position = randomPos;


        // assign health and atk attributes to enemies that will be spawned
        // basically setting up the enemy's attributes
        enemyObj.GetComponent<EnemyManager>().SetupEnemy(enemyToSpawn, this, FindObjectOfType<PlayerManager>().gameObject);
       
        // wait for awhile before spawning again
        yield return new WaitForSeconds(5);


        // if theres enemies left to spawn, continue spawning
        if (enemiesLeftToSpawn > 0)
        {
            StartCoroutine(SpawnEnemyInterval(enemyToSpawn, --enemiesLeftToSpawn));
        }

        // if no more left to spawn, go next wave
        else if (enemiesLeftToSpawn == 0)
        {
            currentWaveIndex++;

            // Check if all waves are completed
            if (currentWaveIndex >= waveList.Count)
            {

                // Check if all enemies are defeated
                StartCoroutine(CheckForWinCondition());
            }

        }

    }

    // get/ create enemy prefab
    private GameObject GetEnemyPrefab(string enemyId)
    {
        GameObject enemyObj;

        // if obj exists in the pool AND if theres enough obj in the pool to be used
        if (ePrefabPool.ContainsKey(enemyId) && ePrefabPool[enemyId].Count > 0)
        {
            // get first available enemy obj
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
            // create new list of enemy obj
            List<GameObject> enemyObjs = new List<GameObject>();

            //add list to the pool
            ePrefabPool[enemyId] = enemyObjs;

            //  instantiate a new enemy object from the prefab
            enemyObj = Instantiate(ePrefab[enemyId]);
        }

        //return enemy obj
        return enemyObj;
    }

    //Return an enemy prefab to the pool
    public void ReturnEnemyPrefab(GameObject enemyObj)
    {
        // basically checking if pool exists for the enemy type 
        // ePrefabpool dictionary uses enemy object's name as the key
        // check if key doesnt exist, then add pool in
        if (!ePrefabPool.ContainsKey(enemyObj.name))
        {
            // Create a new pool if it doesn't exist
            // add in the new empty pool
            
            ePrefabPool.Add(enemyObj.name, new List<GameObject>());
        }

        // if key exists,
        // adding obj to pool
        ePrefabPool[enemyObj.name].Add(enemyObj);
        enemyObj.SetActive(false);
    }


    // Check for win condition after all waves are completed
    private IEnumerator CheckForWinCondition()
    {
        // Wait for a short duration to ensure all enemy deaths are processed
        yield return new WaitForSeconds(2);

        // Check if there are no active enemies left in the scene
        if (FindObjectsOfType<EnemyManager>().Length == 0)
        {

            // Load the WIN scene
            SceneManager.LoadScene("WIN");
        }
    }

}
