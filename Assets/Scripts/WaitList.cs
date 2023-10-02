using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class WaitList : MonoBehaviour
{
    public TMP_Text firstPatient;
    public TMP_Text secondPatient;
    public TMP_Text thirdPatient;
    public TMP_Text fourthPatient;
    public TMP_Text fifthPatient;

    RoomSystem rs;
    List<RoomSystem.Patient> patients;
    private RoomSystem.Patient[] names;
    private string firstPerson;
    private string secondPerson;
    private string thirdPerson;
    private string fourthPerson;
    private string fifthPerson;

    // Start is called before the first frame update
    void Start()
    {
        rs = FindObjectOfType<RoomSystem>();
        names = rs.getWaitlist().ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        getPatients();
    }

    void getPatients()
    {
        names = rs.getWaitlist().ToArray();
        if (names.Length >= 1)
        {
            firstPatient.text = $"{names[0].firstName} {names[0].lastName[0]}.";
        }
        else
        {
            firstPatient.text = "N/A";
        }
        if (names.Length >= 2)
        {
            secondPatient.text = $"{names[1].firstName} {names[1].lastName[0]}.";
        }
        else
        {
            secondPatient.text = "N/A";
        }
        if (names.Length >= 3)
        {
            thirdPatient.text = $"{names[2].firstName} {names[2].lastName[0]}.";
        }
        else
        {
            thirdPatient.text = "N/A";
        }
        if (names.Length >= 4)
        {
            fourthPatient.text = $"{names[3].firstName} {names[3].lastName[0]}.";
        }
        else
        {
            fourthPatient.text = "N/A";
        }
        if (names.Length >= 5)
        {
            fifthPatient.text = $"{names[4].firstName} {names[4].lastName[0]}.";
        }
        else
        {
            fifthPatient.text = "N/A";
        }
    }
}
