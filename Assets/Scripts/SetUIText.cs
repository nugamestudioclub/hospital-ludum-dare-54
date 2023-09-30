using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetUIText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _insurance;
    [SerializeField] private TextMeshProUGUI _injury;
    [SerializeField]
    private string currentFirstName;
    [SerializeField]
    private string currentLastName;
    [SerializeField]
    private injury currentInjury;
    [SerializeField]
    private insurance currentInsurance;

    public class insurance
    {
        public string name;
        public int value;
        public insurance(string getName, int getVal)
        {
            name = getName;
            value = getVal;
        }
        public override string ToString()
        {
            return name;
        }
    }
    public class injury
    {
        public string name;
        //Out of 10
        public int severity;
        public injury(string getName, int getSev)
        {
            name = getName;
            severity = getSev;
        }
        public override string ToString()
        {
            return name;
        }
    }
    private string[] _firstNames = new string[]
    { "Sam", "Jamie", "Blake", "Avery", "Parker", "Riley", "Rowan","James", "Rory", "Logan", "Ryan", "Frankie", "Aubrey", "Alexis", "Morgan",
      "Liam", "Johnny", "Colin", "Clemence", "Allen", "Alec", "Shane", "Isabella", "Russell", "Aliyah", "Bobby", "Stacy", "Mo", "Michael",
      "Bernie", "Michelle", "Virgil", "Adele", "Nick", "Robbie", "Hailey", "Sophie", "Charlotte", "Eldana", "Shirley", "Pierce", "Troy",
      "Britta", "Abed", "Annie", "Jeff", "Gordon", "Paul", "Ethan", "Bo", "Burt", "Ernie", "Charles", "Vaughn", "Chelsea", "Piper", "Karen",
      "Linda", "Ashley", "Matthew", "Ian", "Grace", "Nina", "CJ", "RJ", "BJ"
    };
    
    private string[] _lastNames = new string[]
    {
    "Johnson", "Smith", "Green", "Black", "Brown", "White", "Gordon", "Morgan", "Obama", "Fowler", "Murphy", "McGraw", "Ferrell", "Layton",
    "Washington", "Simpson", "Otto", "Oliver", "Phillips", "Allen", "Hill", "Lewis", "Carmen", "O�Hara", "Gibbs", "Bell", "Hernandez",
    "Safdie", "King", "Dano", "Hawke", "Lawrence", "Mooney", "Norton", "Bailey", "Neville", "Lane", "Miller", "Sanders", "O�Brien",
    "McDonald", "Jordan", "Peterson", "Sanchez", "Huang", "Anderson", "Aarons"
    };

    private insurance[] _insurances = new insurance[]
    {
    new insurance("Kaiser Roll Permanente", 10),
    new insurance("Smiles Inc.", 10),
    new insurance("MidCare Health", 10),
    new insurance("Lowmark Inc.", 10),
    new insurance("Fat Johnson & Johnson", 10),
    new insurance("Cigma Nuts", 10),
    new insurance("RGB Shield", 10),
    new insurance("Inhumana", 10)
    };

    private injury[] _injuries = new injury[]
    {
    new injury("Broken arm", 10),
    new injury("Broken leg", 10),
    new injury("Fractured pinky", 10),
    new injury("Fractured big toe", 10),
    new injury("Skin scrape", 10),
    new injury("Pulled groin", 10),
    new injury("Dislocated shoulder", 10),
    new injury("Dislocated kneecap", 10),
    new injury("Dog bite", 10),
    new injury("Snake bite", 10),
    new injury("ACL tear", 10),
    new injury("Concussion", 10),
    new injury("Third-degree burns", 10),
    new injury("Second-degree burns", 10),
    new injury("First-degree burns", 10),
    new injury("Induced labor", 10),
    new injury("Cardiac arrest", 10),
    new injury("Stroke", 10),
    new injury("Seizure", 10),
    new injury("Blunt force trauma", 10),
    new injury("Brain trauma", 10),
    new injury("Internal organ bleeding", 10),
    new injury("Spinal cord injury", 10),
    new injury("Liver failure", 10),
    new injury("Food poisoning", 10),
    new injury("Appendicitis", 10),
    new injury("Kidney infection", 10),
    new injury("Urinary tract infection", 10),
    new injury("Severe fever", 10),
    new injury("Vomiting blood", 10),
    new injury("Slurred speech", 10),
    new injury("Sore throat", 10),
    new injury("Bronchitis", 10),
    new injury("Common cold", 10),
    new injury("Allergies", 10),
    new injury("Mysterious stomach ache", 10),
    new injury("E coli infection", 10)
    };



    public void SetText()
    {
        SetValues(_name, _firstNames, _lastNames);
        currentInsurance = _insurances[UnityEngine.Random.Range(0, _insurances.Length - 1)];
        SetValues(_insurance, currentInsurance.ToString());
        currentInjury = _injuries[UnityEngine.Random.Range(0, _injuries.Length - 1)];
        SetValues(_injury, currentInjury.ToString());
    }

    // for the name
    public void SetValues(TextMeshProUGUI textMesh, string[] first, string[] last)
    {
        currentFirstName = first[UnityEngine.Random.Range(0, first.Length - 1)];
        currentLastName = last[UnityEngine.Random.Range(0, first.Length - 1)];
        textMesh.text = currentFirstName + ", " + currentLastName;
    }

    // for everything else
    public void SetValues(TextMeshProUGUI textMesh, string text)
    {
        textMesh.text = text;
    }

}
