using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSystem : MonoBehaviour
{

    [SerializeField]
    private static float severityToTimeRatio = 20;
    [SerializeField]
    private static float severityToFailRatio = 7;
    public class Patient 
    {
        public string firstName;
        public string lastName;
        //Time it takes for patient to leave room
        public float fixTime;
        //Out of 100%
        public float failRatio;
        public int insuranceValue;
        Patient(string getFirst, string getLast, int getSeverity, int getInsuranceValue)
        {
            firstName = getFirst;
            lastName = getLast;
            insuranceValue = getInsuranceValue;
            fixTime = getSeverity * severityToTimeRatio;
            failRatio = getSeverity * severityToFailRatio;
        }
    }

    List<Patient> waitList;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
