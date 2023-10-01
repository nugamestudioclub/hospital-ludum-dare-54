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
    private static int hospitalReputation = -20;
    //Adjustable vars
    [SerializeField]
    private TMPro.TextMeshProUGUI fundsText;
    [SerializeField]
    private TMPro.TextMeshProUGUI reputationText;
    [SerializeField]
    private GameObject effectPrefab;
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
    }
    //Helper edit functions
    private static void adjustFunds(int amount)
    {
        hospitalFunds += amount;
        if (amount > 0)
        {
            //Signify increase
        }
        else if (amount < 0)
        {
            //Signify loss
        }
    }
    private static void adjustReputation(int amount)
    {
        hospitalReputation += amount;
        if(amount > 0)
        {
            //Signify increase
        }
        else if(amount < 0)
        {
            //Signify loss
        }
    }
    public static void handleRejectionNorm()
    {
        adjustReputation(rejectionNormRep);
    }
    public static void handleRejectionDeath()
    {
        adjustReputation(rejectionDeathRep);
    }
    public static void handleHospitalDeath()
    {
        adjustReputation(hospitalDeathRep);
    }
    public static void handleHospitalAdmit()
    {
        adjustReputation(hospitalAdmitRep);
    }
    public static void handleHospitalWaitlist()
    {
        adjustReputation(hospitalWaitlistRep);
    }
    // Update is called once per frame
    void Update()
    {
        fundsText.text = "Funds: " + Mathf.Round(hospitalFunds);
        reputationText.text = "Funds: " + Mathf.Round(hospitalReputation);
    }
}
