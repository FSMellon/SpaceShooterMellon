using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : EnemyBase
{
    protected override void Movement()
    {
        transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
    }
}
