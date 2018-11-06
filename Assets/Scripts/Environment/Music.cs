using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    
    AudioSource MyAudioSource;

    //Play the music
    bool playMusic;
    //Detect when you use the toggle, ensures music isn’t played multiple times
    bool musicToggle;

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        MyAudioSource = GetComponent<AudioSource>();
        //Ensure the toggle is set to true for the music to play at start-up
        playMusic = true;
    }

    void Update()
    {
        //Check to see if you just set the toggle to positive
        if (playMusic == true && musicToggle == true)
        {
            //Play the audio you attach to the AudioSource component
            MyAudioSource.Play();
            //Ensure audio doesn’t play more than once
            musicToggle = false;
        }

        //Check if you just set the toggle to false
        if (PlayerHealth.isDead)
        {
            //Stop the audio
            MyAudioSource.Stop();
            //Ensure audio doesn’t play more than once
            playMusic = false;
            musicToggle = true;
        }
    }
}

