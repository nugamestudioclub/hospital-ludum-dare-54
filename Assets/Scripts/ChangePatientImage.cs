using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePatientImage : MonoBehaviour
{
    [SerializeField] private Image _patientImage;

    [SerializeField] private PatientSpritesSO _patientImagesSO;

    private int _currentIndex;

    public void ChangeImage()
    {
        int randomIndex = Random.Range(0, _patientImagesSO.sprites.Length - 1);
        while(randomIndex == _currentIndex)
        {
            randomIndex = Random.Range(0, _patientImagesSO.sprites.Length - 1);
        }
        _patientImage.sprite = _patientImagesSO.sprites[randomIndex];
        _currentIndex = randomIndex;
    }
}
