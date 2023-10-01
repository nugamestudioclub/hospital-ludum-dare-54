using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayEndScript : MonoBehaviour
{
    [SerializeField]
    private float timeOnEachPress;
    private float timeLeftPress = 0;
    [SerializeField]
    private TMPro.TextMeshProUGUI display;
    private string[] displayText;
    private int currentLine = 0;
    private int currentChar = 0;
    private bool finished = false;
    //displays good, okay, and bad
    private string getCurrentState()
    {
        return "ok";
    }
    private void Start()
    {
        timeLeftPress = timeOnEachPress;
        displayText = new string[] {
            "So far " + hospitalMetrics.getDeaths() + " patients have died today",
            "",
            "We have started today with $" + hospitalMetrics.getStartFunds() + " and ended the day with $" + hospitalMetrics.getFunds(),
            "",
            "Our rating started off today at " + hospitalMetrics.getStartReputation() + " and ended today with " + hospitalMetrics.getRep(),
            "",
            "In all honesty I would say that the day went " + getCurrentState(),
            "press any button to start next day"
        };
    }
    // Update is called once per frame
    void Update()
    {
        if (!finished)
        {
            timeLeftPress -= Time.deltaTime;
            if (timeLeftPress < 0)
            {
                timeLeftPress = timeOnEachPress;
                //Is finished
                if(currentLine >= displayText.Length)
                {
                    finished = true;
                }
                else if(currentChar >= displayText[currentLine].Length)
                {
                    display.text += "<br>";
                    currentLine++;
                    currentChar = 0;
                }
                else
                {
                    display.text += displayText[currentLine][currentChar];
                    currentChar++;
                }
            }
        }
    }
}
