using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquashAndStretch : MonoBehaviour
{
    [SerializeField] private float _scaleFactorY = 0.9f; // The maximum X scale factor.
    [SerializeField] private float _scaleFactorX = 1.2f; // The maximum Y scale factor.
    [SerializeField] private float _duration = 0.5f;    // The duration of the animation in seconds.

    private Vector3 _originalScale;
    private float _startTime;

    private void Start()
    {
        _originalScale = transform.localScale;
        _startTime = Time.time;
    }

    private void Update()
    {
        float elapsedTime = Time.time - _startTime;
        float t = Mathf.PingPong(elapsedTime / _duration, 1.0f); // PingPong between 0 and 1 for looping effect
        float scaleY = Mathf.Lerp(_originalScale.y, _scaleFactorY, t);
        float scaleX = Mathf.Lerp(_originalScale.x, _scaleFactorX, t);
        transform.localScale = new Vector3(scaleX, scaleY, 1.0f);
    }
}

