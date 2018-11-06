using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Contains all the code found in WaveMovement and Enemy due to this script being a child of WaveMovement, which itself was a child of Enemy.
public class EnemyShooting : Enemy
{
    //Declares the GameObject "shot" and the position it will be fired from, as well as public bool known as canShoot to be used as a cooldown.
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    public bool canShoot = true;
    public bool firstShot = true;

    private void Update()
    {
        if (firstShot && canShoot)
        {
            firstShot = false;
            canShoot = false;
            Shoot();
        }
        //Makes the enemy shoot a projectile every 1.5 seconds.
        if (canShoot)
        {
            canShoot = false;
            Invoke("Shoot", fireRate);
        }
    }

    void Shoot()
    {
        //Creates a clone of the Shot game object at the position and rotation declared earlier as "shotSpawn", and resets the cooldown.
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        canShoot = true;
    }
}