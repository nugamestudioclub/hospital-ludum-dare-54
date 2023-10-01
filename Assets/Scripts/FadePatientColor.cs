using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadePatientColor : MonoBehaviour
{
    [SerializeField] private Image _imageToFade;
    private float _fadeDuration = 2f; // Duration of the fade in seconds
    private Color[] _targetColors;
    
    private Color _initialColor = Color.white;
    private float _currentFadeTime = 0.0f;
    private bool _isFading = true;


    private Color _targetColor;


    private Color _red = new Color(255f, 128f, 128f, 255f); 
    private Color _yellow = new Color(255f, 255f, 128f, 255f);
    private Color _green = new Color(128f, 255f, 128f, 255f);
    private Color _blue = new Color(128f, 255f, 255f, 255f);
    private Color _purple = new Color(128f, 128f, 255f, 255f);
    private Color _pink = new Color(255f, 128f, 255f, 255f);

    private void Start()
    {
        _targetColors = new Color[] {
        _red,
        _yellow,
        _green,
        _blue,
        _purple,
        _pink
        };
        _targetColor = _targetColors[Random.Range(0, _targetColors.Length - 1)];
    }

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
