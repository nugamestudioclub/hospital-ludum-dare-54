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
      "Linda", "Ashley", "Matthew", "Ian", "Barack", "Grace", "Nina", "CJ", "RJ", "BJ"
    };
    
    private string[] _lastNames = new string[]
    {
    "Johnson", "Smith", "Green", "Black", "Brown", "White", "Gordon", "Morgan", "Obama", "Fowler", "Murphy", "McGraw", "Ferrell", "Layton",
    "Washington", "Simpson", "Otto", "Oliver", "Phillips", "Allen", "Hill", "Lewis", "Carmen", "O'Hara", "Gibbs", "Bell", "Hernandez",
    "Safdie", "King", "Dano", "Hawke", "Lawrence", "Mooney", "Norton", "Bailey", "Neville", "Lane", "Miller", "Sanders", "O'Brien",
    "McDonald", "Jordan", "Peterson", "Sanchez", "Huang", "Anderson", "Aarons"
    };

    private insurance[] _insurances = new insurance[]
    {
    new insurance("Kaiser Roll Permanente", 4000),
    new insurance("Smiles Inc.", 3500),
    new insurance("MidCare Health", 3000),
    new insurance("Lowmark Inc.", 2500),
    new insurance("John & Son", 2000),
    new insurance("Cigma Nuts", 1500),
    new insurance("RGB Shield", 1000),
    new insurance("Inhumana", 500)
    };

    private injury[] _injuries = new injury[]
    {
    new injury("Broken arm", 3),
    new injury("Broken leg", 3),
    new injury("Fractured pinky", 1),
    new injury("Fractured big toe", 1),
    new injury("Skin scrape", 1),
    new injury("Abrasion on arm", 1),
    new injury("Abrasion on leg", 1),
    new injury("Stomach abrasion", 2),
    new injury("Pulled groin", 2),
    new injury("Dislocated shoulder", 3),
    new injury("Dislocated kneecap", 2),
    new injury("Chihuahua bite", 2),
    new injury("Pitbull bite", 3),
    new injury("Snake bite", 4),
    new injury("ACL tear", 2),
    new injury("Concussion", 2),
    new injury("Third-degree burns", 4),
    new injury("Second-degree burns", 3),
    new injury("First-degree burns", 2),
    new injury("Induced labor", 4),
    new injury("Cardiac arrest", 5),
    new injury("Stroke", 5),
    new injury("Seizure", 5),
    new injury("Blunt force trauma", 5),
    new injury("Brain trauma", 5),
    new injury("Internal organ bleeding", 5),
    new injury("Spinal cord injury", 5),
    new injury("Liver failure", 5),
    new injury("Food poisoning", 3),
    new injury("Appendicitis", 4),
    new injury("Kidney infection", 3),
    new injury("Urinary tract infection", 2),
    new injury("Severe fever", 4),
    new injury("Vomiting blood", 5),
    new injury("Slurred speech", 4),
    new injury("Sore throat", 1),
    new injury("Bronchitis", 2),
    new injury("Common cold", 1),
    new injury("Allergies", 1),
    new injury("Mysterious stomach ache", 2),
    new injury("E coli infection", 3)
    };

    public RoomSystem.Patient getPatient()
    {
        return new RoomSystem.Patient(currentFirstName, currentLastName, currentInjury, currentInsurance);
    }
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
        currentLastName = last[UnityEngine.Random.Range(0, last.Length - 1)];
        textMesh.text = currentFirstName + ", " + currentLastName;
    }

   
    // for everything else
    public void SetValues(TextMeshProUGUI textMesh, string text)
    {
        textMesh.text = text;
    }

    private void Start()
    {
        SetText();
    }
}
