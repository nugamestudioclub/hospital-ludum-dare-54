using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PatientSO")]
public class PatientSO : ScriptableObject
{
    public String[] firstNames;
    public String[] lastNames;

    public String[] insurances;
    public String[] injuries;
}
