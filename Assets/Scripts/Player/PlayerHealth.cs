using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //Creates a publically adjustable float for how long the invincibility duration should be,
    //as well as creating game objects for the damaged ship graphic and the sound effect for dying.
    public float iframes;
    public GameObject DamageShip;
    public GameObject DeathSound;
    private bool invincible = false;


    //Makes the three pieces of the health bar individual game objects accessible through the code.
    public GameObject shield1;
    public GameObject shield2;
    public GameObject shield3;
    public GameObject shield4;

    private int shieldCount = 4;

    public static bool isDead;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Activates only when the player collides with an enemy, and is not in an invincibility state.
        if (collision.gameObject.tag == "Enemy" && invincible == false)
        {
            //Immediately makes this block of code inaccessible until the invincibility frames wear off, and activates the damaged ship graphic.
            invincible = true;
            DamageShip.SetActive(true);

            //Three seperate if-functions that deplete the player's health bar by one point, the final one destroying the player.
            if (shieldCount == 4)
            {
                shieldCount--;
                shield4.SetActive(false);
            }
            else if (shieldCount == 3)
            {
                shieldCount--;
                shield3.SetActive(false);
            }
            else if (shieldCount == 2)
            {
                shieldCount--;
                shield2.SetActive(false);
            }
            else if (shieldCount == 1)
            {
                PlayerDeath();
            }
            //Invokes a function that lets the ship be damaged again, after waiting for an amount of seconds decided in the Unity Editor
            Invoke("resetInvulnerability", iframes);
        }
        else if (collision.gameObject.tag == "TankEnemy" && invincible == false)
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        shieldCount = 0;
        shield1.SetActive(false);
        shield2.SetActive(false);
        shield3.SetActive(false);
        shield4.SetActive(false);
        isDead = true;
        DeathSound.SetActive(true);
        Destroy(gameObject);
    }
    

    void resetInvulnerability()
    {
        //Turns off the invincibility status, letting the ship be damaged again, and turns off the damaged ship graphic.
        invincible = false;
        DamageShip.SetActive(false);
    }
}
