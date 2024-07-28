// KEE POH KUN

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    Camera mainCamera;

    // the weapon
    private Transform weapon;

    private float horizontal;
    private float vertical; // new variable for vertical movement
    private float speed;
    private bool isFacingRight = true;

    private float playerHealth;
    private float playerAtk;
    private float playerSpd;

    public Character character;
    public Player player;

    public SpawnerManager spawnerManager;

    // enemy atk
    public float enemyDmg;

    public string enemyId;



    // public SelectionManager selectionManager;

    [SerializeField] private Rigidbody2D rb;

    public void PlayerDeath()
    {
        // 1. destroy player gameobj
        // 2. display game over scene !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! remember to add here :)
        Destroy(gameObject);
    }



    // Start is called before the first frame update
    void Start()
    {
        weapon = transform.Find("weapon");
        if (weapon == null)
        {
            Debug.LogError("weapon not found!");
        }

        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("MainCamera not found!");
        }

        UpdatePlayerStats();
        //player = new Player("0", selectionManager.characterIndex.ToString(), selectionManager.characterIndex.ToString() );
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    // setting player to face dir of mouse
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); // read vertical input

        Flip();

        if (weapon != null && mainCamera != null)
        {
            // Get the mouse position in world coordinates
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z; // Maintain the original z-position

            // Calculate the direction from the parent to the mouse position
            Vector3 direction = (mousePosition - transform.position).normalized;

            // Set the weapon position relative to the parent, keeping a constant distance
            float distance = 1.0f; // Adjust this value to set the distance from the parent
            weapon.position = transform.position + direction * distance;

            // Calculate the angle to face the mouse position
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Adjust the angle by 90 degrees if the weapon's default orientation is upright
            float angleOffset = 90.0f;
            weapon.rotation = Quaternion.Euler(new Vector3(0, 0, angle - angleOffset));
        }
    }

    void FixedUpdate()
    {


        rb.velocity = new Vector2(horizontal * speed, vertical * speed); // apply velocity for both horizontal and vertical movement
    }

    // when player is selected call this func
    public void UpdatePlayerStats()
    {
        Game.GetPlayer().UpdateStats();

        playerHealth = Game.GetPlayer().GetCharacterHealth();
        playerAtk = Game.GetPlayer().GetCharacterAtk();
        playerSpd = Game.GetPlayer().GetCharacterSpeed();

        speed = Game.GetPlayer().GetCharacterSpeed();
        SetSprite(Game.GetCharacterByRefId(Game.GetPlayer().GetCurrentCharacter()).characterSprite);

        
        SetWeaponSprite(Game.GetWeaponByRefId(Game.GetPlayer().GetCurrentCharacterWeapon()).weaponSprite);


       
        // not null anymore, log shows "weapon2" but dk why 
        Debug.Log(Game.GetWeaponByRefId(Game.GetPlayer().GetCurrentCharacterWeapon()).weaponSprite);


    }



    // get name of sprite and run loadsprite function
    public void SetSprite(string name)
    {
        // load sprite and make sprite appear on scene
        AssetManager.LoadSprite(name, (Sprite sp) =>
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sp;


        });
    }


    //  load and set weapon sprite
    public void SetWeaponSprite(string name)
    {
        AssetManager.LoadSprite(name, (Sprite sp) =>
        {
            if (weapon != null)
            {
                weapon.GetComponent<SpriteRenderer>().sprite = sp;
            }
        });

    }



    // setting current health of player using 

    public void SetupHealth(Player playerHealthRef)
    {
        // get total health pass into health
        playerHealth = playerHealthRef.playerHealth;
        gameObject.name = "Player" + playerHealthRef.GetId();
      //  this.spawnerManager = sManager;

    }


    //public void SetUpEnemyRef(Enemy enemyRef, SpawnerManager sManager)
    //{
    //    // shd do this in enemyanager i think
    //    //ref to enemy atk
    //    enemyDmg = enemyRef.enemyAtk;
    //    enemyId = enemyRef.enemyId;
    //    gameObject.name = "Enemy" + enemyRef.enemyId;
    //    this.spawnerManager = sManager;
    //}

    // if enemy collides with player, deduct health
    private void OnTriggerEnter2D(Collider2D other)
    {
        // check if its enemy tag
        if (other.tag == "Enemy")
        {
            enemyDmg = other.GetComponent<EnemyManager>().enemyDmg;

            Debug.Log("player touched enemy");


            MinusPlayerHealth(enemyDmg);


        }
    }

    public void MinusPlayerHealth(float dmg)
    {

        // curHp - dmg = curHp
        playerHealth -= dmg;
        Debug.Log("player health"+ (playerHealth -= dmg));

        Debug.Log("Health minussssss " + dmg);

        // if enemy hp less than or equal 0
        if (playerHealth <= 0)
        {
            // set health to 0 and destroy gameobj
            playerHealth = 0;
            Debug.Log("destroy enemy");
            Destroy(this.gameObject);

            // go to game over scene
            SceneManager.LoadScene("DEATH");
        }
    }


     

}

