using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptWinLoseConditions : MonoBehaviour
{
    private void Start()
    {
        bool success = (float)hospitalMetrics.getFunds() > (float)hospitalMetrics.fundGoal && (float)hospitalMetrics.getRep() > (float)hospitalMetrics.reputationGoal;
        TMPro.TextMeshProUGUI text = GetComponent<TMPro.TextMeshProUGUI>();
        if (success)
        {
            text.text = "Congratulations! You’ve reached our weekly insurance quota and survived the public’s wrath. We can’t thank you enough for your hard work - we couldn’t have done it without you. Check back with us in 15-20 years for a raise.\n";
        }
        else
        {
            text.text = "Oh no, you failed to reach our weekly goals! This is really disappointing, but we understand that everybody has bad weeks; we’re still proud of you :). Please clean out your desk by Monday and sign this NDA.";
        }
        
    }
}
