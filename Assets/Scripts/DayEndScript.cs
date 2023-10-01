using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class DayEndScript : MonoBehaviour
{
    [SerializeField]
    private float timeOnEachPress;
    [SerializeField]
    private float timeLeftPress;
    [SerializeField]
    private TMPro.TextMeshProUGUI display;
    private string[] displayText;
    private int currentLine = 0;
    private int currentChar = 0;
    private bool finished = false;
    //displays good, okay, and bad
    private string getCurrentState()
    {
        bool positive = (float)hospitalMetrics.getFunds() > (float)hospitalMetrics.fundGoal * ((float)hospitalMetrics.getDays() / (float)DigitalClock.lastDay) && (float)hospitalMetrics.getRep() < (float)hospitalMetrics.reputationGoal * ((float)hospitalMetrics.getDays() / (float)DigitalClock.lastDay);
        string[] usingString;
        string[] positiveFeedback = new string[] {
            "Today was a good day for Big Pharma. Keep up the good work, or else.",
            "Don’t stop now, you’re sort of close to winning!",
            "Doesn’t it feel good to save the American public?",
            "These profits look good, but not good enough!",
            "Don’t celebrate yet, there’s still time for you to screw it up.",
            "Here’s a $2.50 gift card to show appreciation for your hard work!",
            "You are an exemplary minimum-wage employee."
        };
        string[] negativeFeedback = new string[]
        {
            "There’s no way you’re actually trying.",
            "Remember that the goal is to make money, dumbass.",
            "Are you intentionally sabotaging us, or do you just suck at this?",
            "Time is ticking, friend. Do better :)",
            "In the time it took to write this sentence, you probably killed another patient.",
            "Good news: you haven’t been fired yet. Bad news: check your email shortly.",
            "HR will be in contact to show you how to do your job.",
            "In our long-term corporate planning, you are of little value to us."
        };
        if (positive)
        {
            usingString = positiveFeedback;
        }
        else
        {
            usingString = negativeFeedback;
        }
        return usingString[Random.Range(0, usingString.Length - 1)];
    }
    private void Start()
    {
        displayText = new string[] {
            "So far " + hospitalMetrics.getDeaths() + " patients have died today",
            "",
            "We have started the day with $" + hospitalMetrics.getStartFunds() + " and ended the day with $" + hospitalMetrics.getFunds(),
            "",
            "We started the day with a " + hospitalMetrics.getStartReputation() + " rating and we have ended the day with a " + hospitalMetrics.getRep() + " rating",
            "",
            "The message from corprate reads: " + getCurrentState()
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
