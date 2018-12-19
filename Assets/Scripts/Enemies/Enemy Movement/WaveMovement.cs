using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Contains all the basic information that every enemy needs, due to inheriting from EnemyBase
public class WaveMovement : EnemyBase
{

    //Variables that can be freely adjusted in the editor to decide how large the curves in the enemy's movement should be.
    [SerializeField]
    [Range(0f, 10f)]
    protected float bigWave, fastWave;
    float spawnTime;

    protected override void Start()
    {
        base.Start();
        spawnTime = Time.time - Random.Range(-1f, 1f);        
    }

    //An overriding movement script that causes the attached object to move in a wave pattern.
    protected override void Movement()
    {
        transform.position = new Vector2(transform.position.x - moveSpeed, Mathf.Sin(Time.time - spawnTime * fastWave) * bigWave);
    }
}
