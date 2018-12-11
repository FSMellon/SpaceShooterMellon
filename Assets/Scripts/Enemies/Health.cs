using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //public int hp;
    //public int scoreValue;
    [SerializeField]
    protected GameObject shotSpark, explosion;

    EnemyBase enemy;

    private void Awake()
    {
        enemy = GetComponent<EnemyBase>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks if the enemy has been hit by a shot
        if (collision.gameObject.tag == "Bullet")
        {

            //If the enemy being hit has health remaining upon being shot, it's health is decreased by one point and the bullet disappears.
            //A particle graphic, labelled here as shotSpark, becomes active, and is then turned off through a function 0.1 seconds later.
            if (enemy.hp > 1)
            {
                enemy.hp -= 1;
                Destroy(collision.gameObject);
                shotSpark.SetActive(true);
                Invoke("removeParticle", 0.1f);
            }
            //If the enemy has no health left, the enemy is removed from the game alongside the bullet that destroyed it.
            else if (enemy.hp == 1)
            {
                ScoreManager.score += enemy.scoreValue;
                Destroy(collision.gameObject);
                if (explosion != null)
                {
                    Instantiate(explosion, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }

    }

    //The function that removes the particle graphic.
    void removeParticle()
    {
        shotSpark.SetActive(false);
    }
}
