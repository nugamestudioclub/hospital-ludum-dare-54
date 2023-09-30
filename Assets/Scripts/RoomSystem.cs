using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSystem : MonoBehaviour
{
    #region patientClass
    [SerializeField]
    private static float severityToTimeRatio = 20;
    [SerializeField]
    private static float severityToFailRatio = 7;
    [SerializeField]
    private static float severityToDieOnTurndown = 7;
    //Patient class used to store information to be processed into rooms
    public class Patient 
    {
        public string firstName;
        public string lastName;
        //Time it takes for patient to leave room
        public float fixTime;
        //Out of 100%
        public float failRatio;
        public float deathOnTurnDownRate;
        public int insuranceValue;
        //Constructor
        public Patient(string getFirst, string getLast, int getSeverity, int getInsuranceValue)
        {
            firstName = getFirst;
            lastName = getLast;
            insuranceValue = getInsuranceValue;
            fixTime = getSeverity * severityToTimeRatio;
            failRatio = getSeverity * severityToFailRatio;
            deathOnTurnDownRate = getSeverity * severityToDieOnTurndown;
        }
    }
    #endregion
    #region var
    [SerializeField]
    private bool debug;
    [SerializeField]
    private int waitListSpace;
    [SerializeField]
    private int roomsAmount;
    //Patients that will fill any rooms upon open spot
    private List<Patient> waitList = new List<Patient>();
    //Rooms avaliable
    private List<Room> rooms = new List<Room>();
    #endregion
    public bool isRoomEmpty(Room givenRoom)
    {
        return givenRoom.isOpen();
    }
    //Returns null if no vacant room is found
    public Room hasVacantRoom()
    {
        if (rooms.Exists(isRoomEmpty))
        {
            return rooms.Find(isRoomEmpty);
        }
        else
        {
            return null;
        }
    }
    //Attempts to add a patient to a unused room
    public bool addPatientToRoom(Patient admittedPatient)
    {
        Room getOpenRoom = hasVacantRoom();
        //Room Found
        if (getOpenRoom != null)
        {
            if (debug)
            {
                print(admittedPatient.firstName + " has moved into room");
            }
            getOpenRoom.admitPatient(admittedPatient);
            hospitalMetrics.handleHospitalAdmit();
            return true;
        }
        //Room Not found
        else
        {
            print(admittedPatient.firstName + " has not moved into room");
            return false;
        }
    }
    //Attempts to add a patient to a waitlist
    public bool addPatientToWaitlist(Patient admittedPatient)
    {
        //Waitlist has room
        if (waitListSpace > waitList.Count)
        {
            if (debug)
            {
                print(admittedPatient.firstName + " has moved into waitlist");
            }
            hospitalMetrics.handleHospitalWaitlist();
            waitList.Add(admittedPatient);
            return true;
        }
        //Waitlist full
        else
        {
            return false;
        }
    }
    public void patientReject(Patient rejectedPatient)
    {
        float deathChance = rejectedPatient.deathOnTurnDownRate;
        //Patient dies
        if(deathChance > Random.Range(0, 100)){
            if (debug)
            {
                print(rejectedPatient.firstName + " died while rejected");
            }
            hospitalMetrics.handleRejectionDeath();
        }
        //Patient lives
        else
        {
            if (debug)
            {
                print(rejectedPatient.firstName + " was fine when rejected");
            }
            hospitalMetrics.handleRejectionNorm();
        }
    }
    void Start()
    {
        for(int i = 0; i < roomsAmount; i++)
        {
            rooms.Add((Room)gameObject.AddComponent(typeof(Room)));
        }
        //DEBUG TESTS
        /*
        Patient sabrinaPat = new Patient("Sabrina", "wow", 5, 1000);
        Patient tomPat = new Patient("tom", "wow", 4, 1000);
        Patient matPat = new Patient("mat", "wow", 3, 1000);
        Patient werPat = new Patient("wer", "wow", 2, 1000);
        Patient amPat = new Patient("am", "wow", 1, 1000);
        Patient teetPat = new Patient("teet", "wow", 3, 1000);
        Patient boewPat = new Patient("boew", "wow", 2, 1000);
        Patient catPat = new Patient("cat", "wow", 1, 1000);
        addPatientToRoom(sabrinaPat);
        addPatientToRoom(tomPat);
        addPatientToRoom(matPat);
        addPatientToRoom(werPat);
        addPatientToRoom(amPat);
        addPatientToWaitlist(teetPat);
        addPatientToWaitlist(boewPat);
        addPatientToWaitlist(catPat);*/
    }
    // Update is called once per frame
    void Update()
    {
        if (waitList.Count > 0 && hasVacantRoom() != null )
        {
            if (debug)
            {
                print("Waitlist patient moved in");
            }
            //Display notification that patient has moved in
            foreach (Patient pat in waitList)
            {
                if (!addPatientToRoom(pat))
                {
                    break;
                }
            }
        }
    }
}
