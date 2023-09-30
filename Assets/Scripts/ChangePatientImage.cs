using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePatientImage : MonoBehaviour
{
    [SerializeField] private Image _patientImage;

    [SerializeField] private PatientSpritesSO _patientImagesSO;

    public void ChangeImage()
    {
        _patientImage.sprite = _patientImagesSO.sprites[Random.Range(0, _patientImagesSO.sprites.Length-1)];
    }
}
