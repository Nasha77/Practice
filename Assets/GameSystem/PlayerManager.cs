using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Camera mainCamera;

    private Transform bat;

    //Player Health
    /*public float Health
    {
        set
        {
            health = value;
            if (health <= 0)
            {
                PlayerDeath();
            }
        }

        get
        {
            return health;
        }
    }
    public float health = 1;*/


    // once health is less than or equal 0, player dies and game over
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

    // setting player to face dir of mouse
    void Update()
    {
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
}

