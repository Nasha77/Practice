// KEE POH KUN

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    Camera mainCamera;

    // the weapon transform
    private Transform weapon;


    // movement variables
    private float horizontal;
    private float vertical; // new variable for vertical movement
    private float speed;
    private bool isFacingRight = true;


    // player stats
    private float playerHealth;
    private float playerAtk;
    private float playerSpd;

    public Character character;
    public Player player;

    public SpawnerManager spawnerManager;

    // enemy atk
    public float enemyDmg;

    public string enemyId;

    [SerializeField] private Rigidbody2D rb;

 


    // Start is called before the first frame update
    void Start()
    {
        // find weapon transform
        weapon = transform.Find("weapon");

        // initialize player stats
        UpdatePlayerStats();
     
    }

    // Flip the player sprite to face the direction of movement
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
    // Handle player movement and weapon direction
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); // read vertical input

        // flip sprite based on movement dir
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

    // handles player movement
    void FixedUpdate()
    {
        // apply velocity for horizontal and vertical movement
        rb.velocity = new Vector2(horizontal * speed, vertical * speed); // apply velocity for both horizontal and vertical movement
    }

    // when player is selected call this function
    // update player stats from game data
    public void UpdatePlayerStats()
    {
        Game.GetPlayer().UpdateStats();

        playerHealth = Game.GetPlayer().GetCharacterHealth();
        playerAtk = Game.GetPlayer().GetCharacterAtk();
        playerSpd = Game.GetPlayer().GetCharacterSpeed();

        speed = Game.GetPlayer().GetCharacterSpeed();


        // update sprites
        SetSprite(Game.GetCharacterByRefId(Game.GetPlayer().GetCurrentCharacter()).characterSprite);
        SetWeaponSprite(Game.GetWeaponByRefId(Game.GetPlayer().GetCurrentCharacterWeapon()).weaponSprite);


    }



    // get name of sprite and run loadsprite function
    // load and set player sprite
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



    // setting current health of player using this ->

    public void SetupHealth(Player playerHealthRef)
    {
        // get total health pass into it
        playerHealth = playerHealthRef.playerHealth;
        gameObject.name = "Player" + playerHealthRef.GetId();
     

    }

    // handles collision with enemies
    // if enemy collides with player, deduct health
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object has the "Enemy" tag
        if (other.tag == "Enemy")
        {
            // get enemy dmg value
            enemyDmg = other.GetComponent<EnemyManager>().enemyDmg;


            // deduct health from player by calling funv and passing enemyDmg for it to deduct in the func later
            MinusPlayerHealth(enemyDmg);


        }
    }

    // Deduct health from the player
    public void MinusPlayerHealth(float dmg)
    {

        // Deduct damage(dmg) from current health(playerHealth)
        playerHealth -= dmg;

        // if enemy hp less than or equal 0
        if (playerHealth <= 0)
        {
            // set health to 0 and destroy player gameobj
            playerHealth = 0; 
            Destroy(this.gameObject);

            // go to game over scene
            SceneManager.LoadScene("DEATH");
        }
    }


     

}

