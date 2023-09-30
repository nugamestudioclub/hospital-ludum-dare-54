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
        Patient(string getFirst, string getLast, int getSeverity, int getInsuranceValue)
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
    public int hasVacantRoom()
    {
        return rooms.FindIndex(isRoomEmpty);
    }
    //Attempts to add a patient to a unused room
    public bool addPatientToRoom(Patient admittedPatient)
    {
        int getOpenIndex = hasVacantRoom();
        //Room Found
        if (getOpenIndex != -1)
        {
            hospitalMetrics.handleHospitalAdmit();
            return true;
        }
        //Room Not found
        else
        {
            return false;
        }
    }
    //Attempts to add a patient to a waitlist
    public bool addPatientToWaitlist(Patient admittedPatient)
    {
        //Waitlist has room
        if (waitListSpace < waitList.Count)
        {
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
            hospitalMetrics.handleRejectionDeath();
        }
        //Patient lives
        else
        {
            hospitalMetrics.handleRejectionNorm();
        }
    }
    void Start()
    {
        for(int i = 0; i < roomsAmount; i++)
        {
            rooms.Add((Room)gameObject.AddComponent(typeof(Room)));
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (waitList.Find(addPatientToRoom) != null)
        {
            //Display notification that patient has moved in
        }
    }
}
