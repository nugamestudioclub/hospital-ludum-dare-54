using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class moveToNextSceneReflection : MonoBehaviour
{
    [SerializeField]
    float timeLeft;
    bool hasPressed = false;
    [SerializeField]
    string nextSceneAddress;
    imageFadeInFadeOut cacheImage;
    private void Start()
    {
        cacheImage = GetComponent<imageFadeInFadeOut>();
    }
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (!hasPressed)
        {
            if (Input.anyKeyDown && timeLeft < 0)
            {
                cacheImage.setActivate(true);
                hasPressed = true;
            }
        }
        else {
            if (cacheImage.getComplete())
            {
                SceneManager.LoadScene(nextSceneAddress);
            }
        }

    }
}
