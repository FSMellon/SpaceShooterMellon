using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FinalDangerLevel : DangerLevel
{
    //Connects the field Text to the Text-component attached to the GameObject.
    Text FinalText;
    void Start()
    {
        FinalText = GetComponent<Text>();
    }


    void Update()
    {
        //Changes the text to display the player's final Danger Level, decided by an Int from the parent script DangerLevel.
        //Additionally, if the player reaches the highest possible Danger Level of 10, the text will instead list the level as MAX.
        if (level < 10)
        {
            FinalText.text = "Danger Level: " + level;
        }
        else
        {
            FinalText.text = "Danger Level: MAX";
        }
    }
}