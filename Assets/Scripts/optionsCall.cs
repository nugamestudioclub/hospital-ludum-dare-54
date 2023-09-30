using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RoomSystem;

public class optionsCall : MonoBehaviour
{
    //Transfers text
    RoomSystem system;
    SetUIText getInfo;
    Patient currentPatient;
    public void setPatient(Patient getPatient) {
        currentPatient = getPatient;
    }

    public void callReject()
    {
        currentPatient = getInfo.getPatient();
        system.patientReject(currentPatient);
        getInfo.SetText();
    }
    public void callAccept()
    {
        currentPatient = getInfo.getPatient();
        if (system.addPatientToRoom(currentPatient))
        {
            getInfo.SetText();
        }
        else
        {
            //Notification that the rooms have been filled
        }
    }
    public void callWaitlist()
    {
        currentPatient = getInfo.getPatient();
        if (system.addPatientToWaitlist(currentPatient))
        {
            getInfo.SetText();
        }
        else
        {
            //Notification that the waitlist have been filled
        }
    }
    private void Start()
    {
        getInfo = GetComponent<SetUIText>();
        system = FindAnyObjectByType<RoomSystem>();
        currentPatient = new Patient("null pat", "null pat", new SetUIText.injury("null", 0), new SetUIText.insurance("null", 0));
    }
}
