using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    private RoomSystem.Patient currentPatient;
    [SerializeField]
    private bool empty;
    //Time until patient is fixed
    [SerializeField]
    private float countDownTime;
    //Calculates upon recieving patient
    [SerializeField]
    private bool willFail;
    public bool isOpen()
    {
        return empty;
    }
    //returns false if patient cannot be admited
    public void admitPatient(RoomSystem.Patient admitPat)
    {
        if(empty)
        {
            empty = false;
            currentPatient = admitPat;
            countDownTime = admitPat.fixTime;
            willFail = admitPat.failRatio > Random.Range(0, 100);
        }
        else {
            print("ERROR: --a patient has been admitted to a full room, check Room--");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countDownTime -= Time.deltaTime;
        //On surgery fix
        if(countDownTime <= 0)
        {
            if (willFail)
            {
                hospitalMetrics.handleHospitalDeath();
                print("Had Died");
            }
            currentPatient = null;
            empty = true;
        }
    }
}
