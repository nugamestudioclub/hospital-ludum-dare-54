using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DigitalClock : MonoBehaviour
{
    public TMP_Text textTimer;

    private float time = 0.0f;
    private float endTime;
    private bool isWorking = true;

    // Start is called before the first frame update
    void Start()
    {
        //create a randomize time as well as assign time for the sticky note
        time = 60f;
        endTime = time + 300.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWorking)
        {
            time += Time.deltaTime * 10;
            DisplayTime();
            isDayOver(time, endTime);
        }
        else
        {
            this.enabled = false;
        }
    }

    void DisplayTime()
    {
        int hours = Mathf.FloorToInt(time / 60.0f);
        int minutes = Mathf.FloorToInt(time - hours * 60);
        textTimer.text = string.Format("{0:00}:{1:00}", hours, minutes);
    }

    public void isDayOver(float actualTime, float quitingTime)
    {
        if (actualTime >= quitingTime)
        {
            isWorking = false;
            Debug.Log("End Day");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //go to next scene and show stats
        }
        else
        {
            isWorking = true;
        } 
    }
}
