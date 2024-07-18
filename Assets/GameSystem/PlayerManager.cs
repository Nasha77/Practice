using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Camera mainCamera;

    private Transform bat;

    private float horizontal;
    private float vertical; // new variable for vertical movement
    private float speed;
    private bool isFacingRight = true;

    public float playerHealth;
    public float playerAtk;
    public float playerSpd;

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
        bat = transform.Find("Bat");
        if (bat == null)
        {
            Debug.LogError("Bat not found!");
        }

        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("MainCamera not found!");
        }
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

        if (bat != null && mainCamera != null)
        {
            // Get the mouse position in world coordinates
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z; // Maintain the original z-position

            // Calculate the direction from the parent to the mouse position
            Vector3 direction = (mousePosition - transform.position).normalized;

            // Set the weapon position relative to the parent, keeping a constant distance
            float distance = 1.0f; // Adjust this value to set the distance from the parent
            bat.position = transform.position + direction * distance;

            // Calculate the angle to face the mouse position
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Adjust the angle by 90 degrees if the weapon's default orientation is upright
            float angleOffset = 90.0f;
            bat.rotation = Quaternion.Euler(new Vector3(0, 0, angle - angleOffset));
        }
    }

    void FixedUpdate()
    {
        speed = Game.GetPlayer().GetCharacterSpeed();

        rb.velocity = new Vector2(horizontal * speed, vertical * speed); // apply velocity for both horizontal and vertical movement
    }

    public void UpdatePlayerStats()
    {
        Player.UpdateStats();

        // playerHealth = player.GetCharacterHealth();
        // playerAtk = player.GetCharacterAtk():
        // playerSpd = player.GetCharacterSpd();

        
        SetSprite(Game.GetCharacterByRefId(Player.GetcurrentCharacter()).image);


    }

    // get name of sprite and run loadsprite function
    public void SetSprite(string name)
    {
        // load sprite and make sprite appear on scene
        AssetManager.LoadSprite(name, (Sprite sp) =>
        {
            this.GetComponent<SpriteRenderer>().sprite = sp;


        });
    }
}

