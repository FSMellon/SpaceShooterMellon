using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    //Declares all parts of the UI that will be hidden upon a Game Over
    [SerializeField]
    GameObject ScoreText;
    [SerializeField]
    GameObject HealthText;
    [SerializeField]
    GameObject DangerText;
    //Declares all parts of the UI that will appear upon a Game Over
    [SerializeField]
    GameObject GameOverText;
    [SerializeField]
    GameObject FinalScoreText;
    [SerializeField]
    GameObject FinalDangerText;

    private void Awake()
    {
        ChangeUI();  
    }

    void Update ()
    {
        //Constantly checks if the player is dead, determined by a bool found in the PlayerHealth script.
        if (PlayerHealth.isDead == true)
        {
            //If the player IS dead, the UI will change accordingly.
            ChangeUI();

            //Reloads the game if the player presses Fire.
            if (Input.GetButtonDown("Fire1"))
            {
                restartCurrentScene();
            }
        }
	}

    //The function that restarts the current scene.
    public void restartCurrentScene()
    {
        //Changes back the isDead bool to state that the player is alive again, then changes the UI accordingly.
        PlayerHealth.isDead = false;
        ChangeUI();
        //Gets the active scene number from the build index, then loads said scene from the top.
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        
    }

    //The function that changes the game's UI from the in-game mode to the Game Over mode.
    //Using the bool isDead once more, the function is able to tell whether or not the player is alive or not and change the UI accordingly.
    public void ChangeUI()
    {
        ScoreText.SetActive(!PlayerHealth.isDead);
        HealthText.SetActive(!PlayerHealth.isDead);
        DangerText.SetActive(!PlayerHealth.isDead);

        GameOverText.SetActive(PlayerHealth.isDead);
        FinalScoreText.SetActive(PlayerHealth.isDead);
        FinalDangerText.SetActive(PlayerHealth.isDead);
    }
}
