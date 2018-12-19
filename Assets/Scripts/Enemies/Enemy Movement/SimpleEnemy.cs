using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Contains all the basic information that every enemy needs, due to inheriting from EnemyBase
public class SimpleEnemy : EnemyBase
{
    //Overrides the empty Movement function present in EnemyBase with one that simply pushes the enemy forward in a linear progression.
    protected override void Movement()
    {
        transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
    }
}
