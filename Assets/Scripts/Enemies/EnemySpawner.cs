using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemylist;

    Vector2 spawnPoint;
  
    [Space]
    float spawnrate = 2f;
    float rand;
    float nextspawn;
    int difficulty = 1000;

    [SerializeField]
    float randRange1;
    [SerializeField]
    float randRange2;

    void Update()
    {
        if (Time.time > nextspawn && PlayerHealth.isDead == false)
        {
            nextspawn = Time.time + spawnrate;
            rand = Random.Range(randRange1, randRange2);
            spawnPoint = new Vector2(transform.position.x, rand);
            Instantiate(enemylist[Random.Range(0, enemylist.Length)], spawnPoint, Quaternion.identity);
        }

        if (ScoreManager.score >= difficulty && difficulty <= 5000)
        {
            spawnrate -= 0.12f;
            difficulty += 500;
            DangerLevel.level++;
        }        
    }
}

