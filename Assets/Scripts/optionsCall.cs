using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RoomSystem;

public class optionsCall : MonoBehaviour
{
    //Transfers text
    float timeLeft = 30;
    RoomSystem system;
    SetUIText getInfo;
    ChangePatientImage getImage;
    Patient currentPatient;
    public void setPatient(Patient getPatient) {
        currentPatient = getPatient;
    }

    public void callReject()
    {
        timeLeft = 30;
        currentPatient = getInfo.getPatient();
        system.patientReject(currentPatient);
        getInfo.SetText();
        getImage.ChangeImage();
    }
    public void callAccept()
    {
        currentPatient = getInfo.getPatient();
        if (system.addPatientToRoom(currentPatient, false))
        {
            timeLeft = 30;
            getInfo.SetText();
            getImage.ChangeImage();
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
            timeLeft = 30;
            getInfo.SetText();
            getImage.ChangeImage();
        }
        else
        {
            //Notification that the waitlist have been filled
        }
    }
    private void Start()
    {
        getImage = GetComponent<ChangePatientImage>(); 
        getInfo = GetComponent<SetUIText>();
        system = FindAnyObjectByType<RoomSystem>();
        currentPatient = new Patient("null pat", "null pat", new SetUIText.injury("null", 0), new SetUIText.insurance("null", 0));
    }
    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0)
        {
            callReject();
        }
    }
}
