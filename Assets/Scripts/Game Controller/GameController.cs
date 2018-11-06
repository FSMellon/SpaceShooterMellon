using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    void Update ()
    {
        //Checks if the player is on the tile screen and, if so, starts the game if the Fire button is pressed
		if (Input.GetButtonDown("Fire1") && SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayerHealth.isDead = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        //Quits the game at any point by pressing Escape
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
