using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    [SerializeField] private int _sceneIndex;

    public void LoadTutorial()
    {
        SceneManager.LoadScene(_sceneIndex);
    }
}
