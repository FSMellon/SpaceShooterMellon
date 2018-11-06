using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWall : MonoBehaviour

{
    //A simple but effective script that destroys anything with collision that touches the wall the script is attached to.
	void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision != null)
        {
            Destroy(collision.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
