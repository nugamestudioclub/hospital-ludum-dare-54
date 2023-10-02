using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonSound : MonoBehaviour
{
    [SerializeField] private AudioClip _buttonSound;
    [SerializeField] private AudioSource _audioSource;

    public void PlaySound()
    {
        _audioSource.PlayOneShot(_buttonSound);
    }
}
