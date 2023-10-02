using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hospitalMetrics : MonoBehaviour
{
    //Two Playerprefs are given
    //"Funds"
    //"Reputation"
    #region vars
    public const string fundsPrefAdress = "Funds";
    public const string reputationPrefAdress = "Reputation";
    private static int hospitalFunds = -20;
    public static int fundGoal = 20000;
    private static int hospitalStartingFund = 0;
    private static int hospitalReputation = -20;
    public static int reputationGoal = 200;
    private static int hospitalStartingReputation = 0;
    private static int hospitalDeaths = 0;
    private static int currentDay = 0;
    //Adjustable vars
    [SerializeField]
    private TMPro.TextMeshProUGUI fundsText;
    [SerializeField]
    private TMPro.TextMeshProUGUI reputationText;
    [SerializeField]
    private int startingFunds;
    [SerializeField]
    private int startingReputation;
    //Reputation adjustments
    [SerializeField]
    private static int rejectionNormRep = -5;
    [SerializeField]
    private static int rejectionDeathRep = -25;
    [SerializeField]
    private static int hospitalDeathRep = -5;
    [SerializeField]
    private static int hospitalAdmitRep = 10;
    [SerializeField]
    private static int hospitalWaitlistRep = 5;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        currentDay++;
        hospitalDeaths = 0;
        //Finds if Funds and reputation have been defined
        //Funds have not been defined
        if (hospitalFunds == -20)
        {
            hospitalFunds = startingFunds;
        }
        //Reputation have not been defined
        if(hospitalReputation == -20)
        {
            hospitalReputation = startingReputation;
        }
        hospitalStartingFund = hospitalFunds;
        hospitalStartingReputation = hospitalReputation;
    }
    //Helper edit functions
    private static void adjustFunds(int amount)
    {
        hospitalFunds += amount;
    }
    private static void adjustReputation(int amount)
    {
        hospitalReputation += amount;
    }
    public static void handleRejectionNorm()
    {
        adjustReputation(rejectionNormRep);
    }
    public static void handleRejectionDeath()
    {
        adjustReputation(rejectionDeathRep);
        hospitalDeaths++;
    }
    public static void handleHospitalDeath()
    {
        adjustReputation(hospitalDeathRep);
        hospitalDeaths++;
    }
    public static void handleHospitalAdmit()
    {
        adjustReputation(hospitalAdmitRep);
    }
    public static void handleHospitalWaitlist()
    {
        adjustReputation(hospitalWaitlistRep);
    }
    public static void handleSuccess(int insuranceValue)
    {
        adjustFunds(insuranceValue);
    }
    //Get/Set functions
    public static int getFunds()
    {
        return hospitalFunds;
    }
    public static int getStartFunds()
    {
        return hospitalStartingFund;
    }
    public static int getStartReputation()
    {
        return hospitalStartingReputation;
    }
    public static int getRep()
    {
        return hospitalReputation;
    }
    public static int getDeaths()
    {
        return hospitalDeaths;
    }
    public static int getDays()
    {
        return currentDay;
    }
    // Update is called once per frame
    void Update()
    {
        fundsText.text = "Funds:" + Mathf.Round(hospitalFunds);
        reputationText.text = "Reputation:" + Mathf.Round(hospitalReputation);
    }
}
