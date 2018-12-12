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
            //Manages the time inbetween each spawn by using the float spawnrate, which is hard-coded above but changes as the difficulty increases.
            nextspawn = Time.time + spawnrate;
            //A random point in the y-axis is then decided for the enemy currently being spawned.
            rand = Random.Range(randRange1, randRange2);
            spawnPoint = new Vector2(transform.position.x, rand);

            //Summons a random prefab from the selection of enemies added in the editor, to the random point in the y-axis defined earlier.
            Instantiate(enemylist[Random.Range(0, enemylist.Length)], spawnPoint, Quaternion.identity);
        }

        //Increases the spawnrate every time the player's score passes the value set by "difficulty".
        //This continues until the player has more than 5000 points, at which point the difficulty level in the game peaks.
        if (ScoreManager.score >= difficulty && difficulty <= 5000)
        {
            spawnrate -= 0.12f;
            difficulty += 500;
            DangerLevel.level++;
            //"difficulty" then increases by 500, meaning an additonal 500 points will be needed in-game to raise the difficulty once more.
        }        
    }
}

