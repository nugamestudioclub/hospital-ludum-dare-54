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
    //Patient class used to store information to be processed into rooms
    public class Patient 
    {
        public string firstName;
        public string lastName;
        //Time it takes for patient to leave room
        public float fixTime;
        //Out of 100%
        public float failRatio;
        public int insuranceValue;
        //Constructor
        Patient(string getFirst, string getLast, int getSeverity, int getInsuranceValue)
        {
            firstName = getFirst;
            lastName = getLast;
            insuranceValue = getInsuranceValue;
            fixTime = getSeverity * severityToTimeRatio;
            failRatio = getSeverity * severityToFailRatio;
        }
    }
    #endregion
    #region var
    [SerializeField]
    private int waitListSpace;
    //Patients that will fill any rooms upon open spot
    private List<Patient> waitList;
    //Rooms avaliable
    private List<Room> rooms;
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
    public bool addPatientToRoom()
    {
        int getOpenIndex = hasVacantRoom();
        //Room Found
        if (getOpenIndex != -1)
        {
            return true;
        }
        //Room Not found
        else
        {
            return false;
        }
    }
    //Attempts to add a patient to a waitlist
    public bool addPatientToWaitlist()
    {
        //Waitlist room
        if (waitListSpace > waitList.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
