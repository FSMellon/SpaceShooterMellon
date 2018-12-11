using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2D;

    //Variables used to regulate the player's movement and speed
    private float x, y;
    

    private bool isFiring;
    private float cooldown;
    [SerializeField]
    private GameObject Thrust, Reverse, shot;
    public Transform shotSpawn;

    private float violentThrust = 0.1f;

    
    [Range(0f, 2f)]
    public float xspeed;
    [Range(0f, 2f)]
    public float yspeed;

    [Range(0f, 2f)]
    public float xspeedfiring;
    [Range(0f, 2f)]
    public float yspeedfiring;


    [Range(0f, 2f)]
    public float fireRate;
    

    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.gravityScale = 0;

    }

    private void Update()
    {
        if (isFiring == false)
        {
            //Sets and constantly updates to the basic movement speed
            x = Input.GetAxis("Horizontal") * xspeed;
            y = Input.GetAxis("Vertical") * yspeed;
        }
        else
        {
            //Sets and constantly updates to the strafing-mode movement speed
            x = Input.GetAxis("Horizontal") * xspeedfiring;
            y = Input.GetAxis("Vertical") * yspeedfiring;
        }

        //Shooting and rate-of-fire management
        if (Input.GetButton("Fire1") && Time.time > cooldown)
        {
            cooldown = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

        //Activates a boost effect on the ship whenever the player moves forward while not shooting
        if (x > 0 && isFiring == false)
        {
            Thrust.SetActive(true);
            //isBoosting = true;
            if (violentThrust >= 0)
            {
                violentThrust -= Time.deltaTime;
            }
            else
            {
                Thrust.transform.Rotate(180,0,0);
                violentThrust = 0.1f;
            }
        }
        else
        {
            Thrust.SetActive(false);
            //isBoosting = false;
        }

        //Activates a backwards-boost effect on the ship whenever the player moves in reverse while not shooting
        if (x < 0 && isFiring == false)
        {
            Reverse.SetActive(true);
            //isReversing = true;
            if (violentThrust >= 0)
            {
                violentThrust -= Time.deltaTime;
            }
            else
            {
                violentThrust = 0.1f;
            }
        }
        else
        {
            Reverse.SetActive(false);
            //isReversing = false;
        }

        

        //Checks if the player is holding down the shoot button, to change a variable affecting the player movement.
        if (Input.GetButton("Fire1"))
        {
            isFiring = true;
        }
        else
        {
            isFiring = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2D.velocity = new Vector2(x, y);
    }
}

//0.8
//0.45