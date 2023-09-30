using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionsCall : MonoBehaviour
{
    //Transfers text
    RoomSystem system = FindAnyObjectByType<RoomSystem>();

    public void callReject()
    {
        if (system.patientReject())
        {

        }
    }
    public void callAccept()
    {
        if(c)
    }
    public void callWaitlist()
    {

    }
}
