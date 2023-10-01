using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class imageFadeInFadeOut : MonoBehaviour
{
    [SerializeField]
    float transitionSpeed;
    [SerializeField]
    bool activated;
    [SerializeField]
    bool complete;
    [SerializeField]
    bool fadeIn;
    [SerializeField]
    Image cacheImage;
    // Start is called before the first frame update
    void Start()
    {
        cacheImage = GetComponent<Image>();
    }
    public void setActivate(bool set)
    {
        activated = set;
    }
    public bool getComplete()
    {
        return complete;
    }
    // Update is called once per frame
    void Update()
    {
        if (!complete)
        {
            if (fadeIn)
            {
                if (cacheImage.color.a + (Time.deltaTime * transitionSpeed) >= 1)
                {
                    cacheImage.color = new Color(cacheImage.color.r, cacheImage.color.b, cacheImage.color.g, 1);
                    complete = true;
                }
                else
                {
                    cacheImage.color = new Color(cacheImage.color.r, cacheImage.color.b, cacheImage.color.g, cacheImage.color.a + (Time.deltaTime * transitionSpeed));
                }
            }
            else
            {
                if (cacheImage.color.a - (Time.deltaTime * transitionSpeed) <= 0)
                {
                    cacheImage.color = new Color(cacheImage.color.r, cacheImage.color.b, cacheImage.color.g, 0);
                    complete = true;
                }
                else
                {
                    cacheImage.color = new Color(cacheImage.color.r, cacheImage.color.b, cacheImage.color.g, cacheImage.color.a - (Time.deltaTime * transitionSpeed));
                }
            }
        }
    }
}
