using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    //Declares the public variable for the enemy's speed, which varies between every enemy in the game.
    [SerializeField]
    protected float moveSpeed;
    public int hp, scoreValue;
    Rigidbody2D rb;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    //Activates the "movement" function for all enemies, and destroys the enemy once the player dies for a cleaner-looking Results screen.
    private void Update()
    {
        Movement();
        if (PlayerHealth.isDead)
        {
            Destroy(gameObject);
        }
    }

    //Keeps the enemies that make use of this function moving forward at a consistent speed.
    protected abstract void Movement();
}