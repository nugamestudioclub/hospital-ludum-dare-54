using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
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
        return "ok";
    }
    private void Start()
    {
        displayText = new string[] {
            "PRESS ANY BUTTON TO RESTART"
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
                if (currentLine >= displayText.Length)
                {
                    finished = true;
                }
                else if (currentChar >= displayText[currentLine].Length)
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
