using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleScript : MonoBehaviour
{
    Camera mainCamera;
    private Color[] colors = { Color.red, Color.green, Color.blue };
    private int currentColorIndex = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        Transform hamsterSword = transform.Find("hamsterSword");
        hamsterSword.transform.localPosition = Vector2.one;

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mainCamera = Transform.FindObjectOfType<Camera>();
        Debug.Log(mainCamera.name);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.up = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition) - (Vector2)this.transform.position;
    }

    private void OnMouseDown()
    {
        Debug.Log("click" + name);
        transform.Find("hamsterSword").GetComponentInChildren<SpriteRenderer>().color = colors[currentColorIndex];

        // Move to the next color in the array
        currentColorIndex = (currentColorIndex + 1) % colors.Length;
    }
}
