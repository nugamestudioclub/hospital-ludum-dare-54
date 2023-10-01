using UnityEngine;
using UnityEngine.UI;

public class FadeToRed : MonoBehaviour
{
    [SerializeField] private Image imageToFade;
    [SerializeField] private float fadeDuration = 2.0f; // Duration of the fade in seconds
    [SerializeField] private Color targetColor = new Color(255, 128, 128);
    
    private Color initialColor = Color.white;
    private float currentFadeTime = 0.0f;
    private bool isFading = true;

    private void Update()
    {
        if (isFading)
        {
            currentFadeTime += Time.deltaTime;
            float t = Mathf.Clamp01(currentFadeTime / fadeDuration);
            imageToFade.color = Color.Lerp(initialColor, targetColor, t);

            if (t >= 1.0f)
            {
                isFading = false;
            }
        }
    }
}
