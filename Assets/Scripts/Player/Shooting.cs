using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    Rigidbody2D bulletRB2D;
    [Range(0f, 10f)]
    public float FireSpeed;
    public bool EnemyShooting;

    void Start()
    {
        //Gets the Rigidbody of the bullet as to give it physics
        //Then changes which directions the shot will go in based on if it was fired by an enemy or the Player.
        bulletRB2D = GetComponent<Rigidbody2D>();
        if (EnemyShooting)
        {
            bulletRB2D.velocity = -transform.right * FireSpeed;
        }
        if (!EnemyShooting)
        {
            bulletRB2D.velocity = transform.right * FireSpeed;
        }
    }

    void Update()
    {
        if (PlayerHealth.isDead)
        {
            Destroy(gameObject);
        }
    }

    //Note the lack of a Shot Despawning function: This is because an invisible barrier that can only collide with the player's shots 
    //is used to more effectively erase said shots after they reached a fixed distance. Enemy shots are erased using the same off-screen
    //KillWall that destroys the enemies as well.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroys the shot if it collides with the Player
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
