using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeDay : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _dayText;

    // Update is called once per frame
    void Update()
    {
        _dayText.text = "Day " + hospitalMetrics.getDays();
    }
}
