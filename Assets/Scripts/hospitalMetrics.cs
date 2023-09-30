using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hospitalMetrics : MonoBehaviour
{
    //Two Playerprefs are given
    //"Funds"
    //"Reputation"
    #region
    public const string fundsPrefAdress = "Funds";
    public const string reputationPrefAdress = "Reputation";
    private int startingFunds;
    private int startingReputation;
    private static int hospitalFunds = -20;
    private static int hospitalReputation = -20;
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
    public void adjustFunds(int amount)
    {
        hospitalFunds += amount;
    }
    public void adjustReputation(int amount)
    {
        hospitalReputation += amount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
