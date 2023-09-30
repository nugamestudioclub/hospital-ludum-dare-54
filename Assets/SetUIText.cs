using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class SetUIText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _insurance;
    [SerializeField] private TextMeshProUGUI _injury;






    [SerializeField] private PatientSO _patientSO;

    public void SetText()
    {
        SetValues(_name, _patientSO.firstNames, _patientSO.lastNames);
        SetValues(_insurance, _patientSO.insurances);
        SetValues(_injury, _patientSO.injuries);
    }

    // for the name
    public void SetValues(TextMeshProUGUI textMesh, string[] first, string[] last)
    {
        textMesh.text = first[Random.Range(0, first.Length - 1)] + ", " + last[Random.Range(0, last.Length - 1)];
    }

    // for everything else
    public void SetValues(TextMeshProUGUI textMesh, string[] array)
    {
        textMesh.text = array[Random.Range(0, array.Length - 1)];
    }

}
