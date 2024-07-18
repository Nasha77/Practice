using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical; // new variable for vertical movement
    private float speed;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); // read vertical input

       

        Flip();
    }

    void FixedUpdate()
    {
        speed = Game.GetPlayer().GetCharacterSpeed();

        rb.velocity = new Vector2(horizontal * speed, vertical * speed); // apply velocity for both horizontal and vertical movement
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

    
}