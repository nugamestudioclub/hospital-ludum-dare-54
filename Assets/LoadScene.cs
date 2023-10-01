using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTutorialScene : MonoBehaviour
{
    [SerializeField] private int _tutorialSceneIndex;

    public void LoadTutorial()
    {
        SceneManager.LoadScene(_tutorialSceneIndex);
    }
}
