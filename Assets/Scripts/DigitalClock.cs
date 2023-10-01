using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DigitalClock : MonoBehaviour
{
    [SerializeField]
    private imageFadeInFadeOut cacheTransitionImage;
    [SerializeField]
    private GameObject cacheTransitionGameobject;
    public TMP_Text textTimer;
    [SerializeField]
    private float time;
    [SerializeField]
    private float endTime;
    [SerializeField]
    private string dayEndScene;
    [SerializeField]
    private string gameEndScene;
    [SerializeField]
    private int lastDay;
    [SerializeField]
    private bool hasEnded;
    private bool isWorking = true;

    // Start is called before the first frame update
    void Start()
    {
        cacheTransitionGameobject.SetActive(false);
        cacheTransitionImage = cacheTransitionGameobject.GetComponent<imageFadeInFadeOut>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWorking)
        {
            time += Time.deltaTime;
            DisplayTime();
            isDayOver(time, endTime);
        }
        if (hasEnded)
        {
            if (cacheTransitionImage.getComplete())
            {
                if (hospitalMetrics.getDays() >= lastDay)
                {
                    SceneManager.LoadScene(gameEndScene);
                }
                else
                {
                    SceneManager.LoadScene(dayEndScene);
                }
            }
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
            hasEnded = true;
            cacheTransitionGameobject.SetActive(true);
            cacheTransitionImage.setActivate(true);
            
            //go to next scene and show stats
        }
        else
        {
            isWorking = true;
        } 
    }
}
