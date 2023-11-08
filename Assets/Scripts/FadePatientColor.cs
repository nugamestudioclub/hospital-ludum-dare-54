using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadePatientColor : MonoBehaviour
{
    [SerializeField] private Image _imageToFade;
    [SerializeField] private float _fadeDuration = 50f; // Duration of the fade in seconds
    
    private Color _initialColor = Color.white;
    private float _currentFadeTime = 0.0f;
    private bool _isFading = true;


    [SerializeField] private Color _targetColor;



    private void Update()
    {
        if (_isFading)
        {
            _currentFadeTime += Time.deltaTime;
            float t = Mathf.Clamp01(_currentFadeTime / _fadeDuration);
            _imageToFade.color = Color.Lerp(_initialColor, _targetColor, t);

            if (t >= 1.0f)
            {
                _isFading = false;
            }
        }
    }
}
