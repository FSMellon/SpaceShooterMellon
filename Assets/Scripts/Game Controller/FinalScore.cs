using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FinalScore : ScoreManager
{
    //Connects the field Text to the Text-component attached to the GameObject
    Text FinalText;
    void Start ()
    {
        FinalText = GetComponent<Text>();
    }	

    //Changes the text to display the current score, as obtained by the parent script ScoreManager.
	void Update ()
    {
        FinalText.text = "Final Score: " + score;
    }
}
