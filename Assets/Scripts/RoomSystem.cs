using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoomSystem : MonoBehaviour
{
    [SerializeField]
    public static bool debug = true;
    #region patientClass
    [SerializeField]
    private static float severityToTimeRatio = 25;
    [SerializeField]
    private static float severityToFailRatio = 10;
    [SerializeField]
    private static float severityToDieOnTurndown = 10;
    [SerializeField]
    public Sprite vacant;
    [SerializeField]
    public Sprite sick;
    [SerializeField]
    public Sprite healthy;
    [SerializeField]
    public Sprite dead;

    //Patient class used to store information to be processed into rooms
    public class Patient 
    {
        //Time it takes for patient to leave room
        public float fixTime;
        //Out of 100%
        public float failRatio;
        public float deathOnTurnDownRate;
        public int insuranceValue;
        //For flavor text
        public string firstName;
        public string lastName;
        public string injuryName;
        public string insuranceName;
        //Constructor
        public Patient(string getFirst, string getLast, SetUIText.injury getInjury, SetUIText.insurance getInsurance)
        {
            firstName = getFirst;
            lastName = getLast;
            insuranceValue = getInsurance.value;
            fixTime = getInjury.severity * severityToTimeRatio;
            failRatio = getInjury.severity * severityToFailRatio;
            deathOnTurnDownRate = getInjury.severity * severityToDieOnTurndown;
            insuranceName = getInsurance.name;
            injuryName = getInjury.name;
        }
    }
    #endregion
    #region roomClass
    [SerializeField]
    private static Color defaultColor = Color.white;
    [SerializeField]
    private static Color filledColor = Color.white;
    public class Room
    {
        [SerializeField]
        public Image fillRepersent;
        [SerializeField]
        TMPro.TextMeshProUGUI timeLeftRepersent;
        [SerializeField]
        private Patient currentPatient;
        [SerializeField]
        private bool empty = true;
        //Time until patient is fixed
        [SerializeField]
        private float countDownTime;
        //Calculates upon recieving patient
        [SerializeField]
        private bool willFail;
        private Sprite vacant;
        private Sprite sick;
        private Sprite healthy;
        private Sprite dead;

        public bool isOpen()
        {
            return empty;
        }
        public Room(Image correspondSymbol, TMPro.TextMeshProUGUI correspondText, Sprite vacant, Sprite sick, Sprite healthy, Sprite dead)
        {
            this.vacant = vacant;
            this.sick = sick;
            this.healthy = healthy;
            this.dead = dead;
            fillRepersent = correspondSymbol;
            timeLeftRepersent = correspondText;
        }
        //returns false if patient cannot be admited
        public void admitPatient(Patient admitPat)
        {
            if (empty)
            {
                fillRepersent.GetComponent<Image>().sprite = sick;
                empty = false;
                currentPatient = admitPat;
                countDownTime = admitPat.fixTime;
                willFail = admitPat.failRatio > Random.Range(0, 100);
            }
            else
            {
                print("ERROR: --a patient has been admitted to a full room, check Room--");
            }
        }
        public void onUpdate()
        {

            if (!empty)
            {
                timeLeftRepersent.text = "" + (Mathf.Round(countDownTime)) ;
                fillRepersent.color = filledColor;
                countDownTime -= Time.deltaTime;
                //On surgery fix
                if (countDownTime <= 0)
                {
                    fillRepersent.GetComponent<Image>().sprite = vacant;
                    if (willFail)
                    {
                        // TODO: Do death animation
                        hospitalMetrics.handleHospitalDeath();
                        if (debug)
                        {
                            print(currentPatient.firstName + "has died in room");
                        }
                        if (!FindAnyObjectByType<NoteCardsSystem>().displayMessage(currentPatient.firstName + " has died in the room from " + currentPatient.injuryName))
                        {
                            print("notecard fail");
                        }
                    }
                    else
                    {
                        if (!FindAnyObjectByType<NoteCardsSystem>().displayMessage(currentPatient.firstName + "has survived and paid out $" + currentPatient.insuranceValue + " from " + currentPatient.insuranceName))
                        {
                            print("notecard fail");
                        }
                        if (debug)
                        {
                            print(currentPatient.firstName + "has survived and paid out $" + currentPatient.insuranceValue + " from " + currentPatient.insuranceName);
                        }
                      
                        hospitalMetrics.handleSuccess(currentPatient.insuranceValue);
                    }
                    empty = true;
                }
            }
            else
            {
                //fillRepersent.color = defaultColor;
            }
        }
    }
    #endregion
    #region var
    [SerializeField]
    private NoteCardsSystem cacheNotes;
    [SerializeField]
    private int waitListSpace;
    [SerializeField]
    private int roomsAmount;
    [SerializeField]
    private Image[] roomRepersent;
    [SerializeField]
    private TMPro.TextMeshProUGUI[] timeRepersent;
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
    public bool addPatientToRoom(Patient admittedPatient, bool fromWaitlist)
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
            if (!fromWaitlist)
            {
                hospitalMetrics.handleHospitalAdmit();
            }
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
            if(!cacheNotes.displayMessage(rejectedPatient.firstName + " died while rejected"))
            {
                print("notecard fail");  
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

    public List<Patient> getWaitlist()
    {
        return waitList;
    }
    void Start()
    {
        cacheNotes = FindAnyObjectByType<NoteCardsSystem>();
        for(int i = 0; i < roomsAmount; i++)
        {
            rooms.Add(new Room(roomRepersent[i], timeRepersent[i], vacant, sick, healthy, dead));
        }
        /*
        Patient sabrina = new Patient("sabrina", "w", 3, 1);
        Patient sabrina1 = new Patient("sabrina1", "w", 1, 1);
        Patient sabrina2 = new Patient("sabrina2", "w", 2, 1);
        Patient sabrina3 = new Patient("sabrina3", "w", 5, 1);
        Patient sabrina4 = new Patient("sabrina4", "w", 6, 1);
        Patient sabrina5 = new Patient("sabrina5", "w", 4, 1);
        Patient sabrina6 = new Patient("sabrina6", "w", 3, 1);
        Patient sabrina7 = new Patient("sabrina7", "w", 1, 1);
        Patient sabrina8 = new Patient("sabrina8", "w", 2, 1);
        Patient bob = new Patient("bob", "w", 5, 1);
        Patient bob1 = new Patient("bob1", "w", 5, 1);
        Patient bob2 = new Patient("bob2", "w", 5, 1);
        Patient bob3 = new Patient("bob3", "w", 5, 1);
        addPatientToRoom(sabrina);
        addPatientToRoom(sabrina1);
        addPatientToRoom(sabrina2);
        addPatientToRoom(sabrina3);
        addPatientToRoom(sabrina4);
        addPatientToRoom(sabrina5);
        addPatientToWaitlist(bob);
        addPatientToWaitlist(bob1);
        addPatientToWaitlist(bob2);
        addPatientToWaitlist(bob3);*/
    }
    // Update is called once per frame
    void Update()
    {
        if (waitList.Count > 0 && hasVacantRoom() != null )
        {
            //Display notification that patient has moved in
            foreach (Patient pat in waitList.ToArray())
            {
                if (debug)
                {
                    print("patient "+ pat.firstName + " moved in from waitlist");
                }
                if (!FindAnyObjectByType<NoteCardsSystem>().displayMessage("patient " + pat.firstName + " moved in from waitlist"))
                {
                    print("notecard fail");
                }
                if (addPatientToRoom(pat, true))
                {
                    waitList.Remove(pat);
                }
                else
                {
                    break;
                }
            }
        }
        foreach (Room room in rooms)
        {
            room.onUpdate();
        }
    }
}
