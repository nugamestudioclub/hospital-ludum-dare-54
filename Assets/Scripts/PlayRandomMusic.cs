using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip[] _songs;

    private int _currentIndex;

    private void Awake()
    {
        _audioSource.clip = _songs[Random.Range(0, _songs.Length - 1)];
        _audioSource.Play();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_audioSource.isPlaying)
        {
            int randomIndex = Random.Range(0, _songs.Length - 1);
            while (randomIndex == _currentIndex)
            {
                randomIndex = Random.Range(0, _songs.Length - 1);
            }
            _audioSource.clip = _songs[randomIndex];
            _currentIndex = randomIndex;
            _audioSource.Play();

        }
    }
}
