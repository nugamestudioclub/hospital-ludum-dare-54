using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptWinLoseConditions : MonoBehaviour
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


    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _winSong;
    [SerializeField] private AudioClip _loseSong;


    //displays good, okay, and bad
    private string getCurrentState()
    {
        return "ok";
    }
    private void Start()
    {
        bool success = (float)hospitalMetrics.getFunds() > (float)hospitalMetrics.fundGoal && (float)hospitalMetrics.getRep() > (float)hospitalMetrics.reputationGoal;

        if (success)
        {
            _audioSource.clip = _winSong;
        }
        else
        {
            _audioSource.clip = _loseSong;
        }
        _audioSource.Play();

        TMPro.TextMeshProUGUI text = GetComponent<TMPro.TextMeshProUGUI>();
        if (success)
        {
            displayText = new string[] {
                "Congratulations!",
                "You’ve reached our weekly insurance quota and survived the public’s wrath.",
                "We can’t thank you enough for your hard work - we couldn’t have done it without you.",
                "Check back with us in 15-20 years for a raise."
            };
         
        }
        else
        {
            displayText = new string[] {
                "Oh no, you failed to reach our weekly goals!",
                "This is really disappointing, but we understand that everybody has bad weeks; we’re still proud of you :).",
                "Please clean out your desk by Monday and sign this NDA."
            };
        }
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
