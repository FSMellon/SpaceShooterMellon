using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DangerLevel : MonoBehaviour
{
    //Sets up the player's default danger level, and a reference to the Text component.
    public static int level = 1;        
    Text text;                      


    private void Start()
    {
        //Set up the reference.
        text = GetComponent<Text>();

        //Reset the score.
        level = 1;
    }


    void Update()
    {
        //Constantly updates the text to display the player's current danger level from 1-9.
        if (level < 10)
        {
            
            text.text = " DANGER LEVEL: " + level;
        }
        //Once the danger level hits its peak at level 10, the number is replaced with "MAX" and the text changes to red.
        else
        {
            text.text = " DANGER LEVEL: MAX";
            text.color = Color.red;
        }
    }
}