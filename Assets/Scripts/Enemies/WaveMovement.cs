using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Contains all the code found in Enemy due to being a child of said script.
public class WaveMovement : Enemy
{

    //Variables that can be freely adjusted in the editor to decide how large the curves in the enemy's movement should be.
    [Range(0f, 10f)]
    public float BigWave, fastWave;
    float spawnTime;

    private void Start()
    {
        spawnTime = Time.time - Random.Range(-1f, 1f);        
    }

    //An overriding movement script that causes the attached object to move in a wave pattern.
    protected override void Movement()
    {
        transform.position = new Vector2(transform.position.x - speed, Mathf.Sin(Time.time - spawnTime * fastWave) * BigWave);
    }
}
