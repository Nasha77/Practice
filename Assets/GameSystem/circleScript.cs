using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleScript : MonoBehaviour
{
    Camera mainCamera;
    private Color[] colors = { Color.red, Color.green, Color.blue };
    private int currentColorIndex = 0;
    private Transform bat;

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

    // Update is called once per frame
    void Update()
    {
        if (bat != null && mainCamera != null)
        {
            // Get the mouse position in world coordinates
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z; // Maintain the original z-position

            // Calculate the direction from the parent to the mouse position
            Vector3 direction = (mousePosition - transform.position).normalized;

            // Set the sword position relative to the parent, keeping a constant distance
            float distance = 1.0f; // Adjust this value to set the distance from the parent
            bat.position = transform.position + direction * distance;

            // Calculate the angle to face the mouse position
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Rotate the sword to face the mouse position
            // Adjust by 0 degrees if the sword's tip points to the right in the default sprite orientation
            bat.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("click " + name);
        if (bat != null)
        {
            bat.GetComponent<SpriteRenderer>().color = colors[currentColorIndex];

            // Move to the next color in the array
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
        }
    }
}
