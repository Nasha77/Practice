using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // set how powerful enemy is
    public float damage = 1;

    //enemy current health
    private float curHp;
    // enemy atk
    public float enemyDmg;

    public float enemySpd;

    public string enemyId;

    // if u need can use findobjbytype
    //public PlayerManager playerManager;

    public SpawnerManager spawnerManager;

    public QuestManager questManager;

   

    List<WaveSpawnerRef> waveList = Game.GetWaveList();

    private GameObject player;

    private float dist;


    // setting current health of enemy using 


    private void Start()
    {

        // put enemy atk as dmg
        // Enemy dmg = Game.GetEnemyByRefId(waveList[spawnerManager.waveIndex].enemyId);

       
       
    }

    // Update is called once per frame
    void Update()
    {

        if (player == null)
        {
            return;
            
        }

        dist = Vector2.Distance(transform.position, player.transform.position);
        Vector2 dir = player.transform.position - transform.position;

        // enemy move towards the player
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemySpd * Time.deltaTime);
    }

    // check if enemy died for the quest
    public void Died()
    {
        // Call the OnEnemyKilled method on the QuestManager script
        questManager.OnEnemyKilled();
    }


    // getting input from the func,, set up health and atk
    public void SetupEnemy(Enemy enemyRef, SpawnerManager spManager, GameObject player)
    {
        // get total health of an enemy in ENEMY and pass into curHp
        curHp = enemyRef.enemyHealth;
        enemyDmg = enemyRef.enemyAtk;
        enemySpd = enemyRef.enemySpeed;
        enemyId = enemyRef.enemyId;
        gameObject.name = "Enemy" + enemyRef.enemyId;
        this.spawnerManager = spManager;

        this.player = player;


    }
   

    public void MinusHealth(float dmg)
    {
        // curHp - dmg = curHp
        curHp -= dmg;

        Debug.Log("enemy healh deduct " + dmg);
        // if enemy hp less than or equal 0
        if(curHp <= 0)
        {
            // set health to 0 and destroy gameobj
            curHp = 0;
            Debug.Log("destroy enemy" );

            // once enemy dies, call the func for quest
            Died();

            spawnerManager.ReturnEnemyPrefab(this.gameObject);
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



        ////PLAYER
        //if (other.tag == "Player")
        //{
        //    //deal dmg to player
        //    //Player player = other.GetComponent<Player>();
        //    Player player = Game.GetPlayer();

        //    if (player != null)
        //    {
        //        //Debug.Log("HEALTH" + (player.playerHealth -= damage));
        //        //player.playerHealth -= damage;

        //        MinusHealth(100);
        //    }

        //    //if(player.playerHealth < 0)
        //    //{
        //    //    //KILLS PLAYER
        //    //    playerManager.PlayerDeath();
        //    //}
        //}







        // change sprite in gameobj
        // or change prefab, use prefab for different characters



        
    }



}


