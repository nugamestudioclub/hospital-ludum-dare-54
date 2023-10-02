using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    public void LoadTutorial()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
