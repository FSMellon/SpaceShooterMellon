using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Declares the public variable for the enemy's speed, which varies between every enemy in the game.
    public float speed;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    //Activates the "movement" function for all enemies, and destroys the enemy once the player dies for a cleaner-looking Results screen.
    private void FixedUpdate()
    {
        Movement();
        if (PlayerHealth.isDead)
        {
            Destroy(gameObject);
        }
    }

    //Keeps the enemies that make use of this function moving forward at a consistent speed.
    protected virtual void Movement()
    {
        transform.position = new Vector2(transform.position.x - speed, transform.position.y);
    }
}
