using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetUIText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _insurance;
    [SerializeField] private TextMeshProUGUI _injury;

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
    "Washington", "Simpson", "Otto", "Oliver", "Phillips", "Allen", "Hill", "Lewis", "Carmen", "O’Hara", "Gibbs", "Bell", "Hernandez",
    "Safdie", "King", "Dano", "Hawke", "Lawrence", "Mooney", "Norton", "Bailey", "Neville", "Lane", "Miller", "Sanders", "O’Brien",
    "McDonald", "Jordan", "Peterson", "Sanchez", "Huang", "Anderson", "Aarons"
    };

    private string[] _insurances = new string[]
    {
    "Kaiser Roll Permanente", "Smiles Inc.", "MidCare Health", "Lowmark Inc.", "Fat Johnson & Johnson", "Cigma Nuts", "RGB Shield", "Inhumana"
    };


    private string[] _injuries = new string[]
    {
    "Broken arm", "Broken leg", "Fractured pinky", "Fractured big toe", "Skin scrape", "Pulled groin", "Dislocated shoulder",
    "Dislocated kneecap", "Dog bite", "Snake bite", "ACL tear", "Concussion", "Third-degree burns", "Second-degree burns",
    "First-degree burns", "Pregnancy", "Cardiac arrest", "Stroke", "Seizure", "Blunt force trauma", "Brain trauma",
    "Internal organ bleeding", "Spinal cord injury", "Liver failure", "Food poisoning", "Appendicitis", "Kidney infection",
    "Urinary tract infection", "Severe fever", "Vomiting blood", "Slurred speech", "Sore throat", "Bronchitis", "Common cold",
    "Allergies", "Mysterious stomach ache", "E coli infection"
    };



    public void SetText()
    {
        SetValues(_name, _firstNames, _lastNames);
        SetValues(_insurance, _insurances);
        SetValues(_injury, _injuries);
    }

    // for the name
    public void SetValues(TextMeshProUGUI textMesh, string[] first, string[] last)
    {
        textMesh.text = first[Random.Range(0, first.Length - 1)] + ", " + last[Random.Range(0, last.Length - 1)];
    }

    // for everything else
    public void SetValues(TextMeshProUGUI textMesh, string[] array)
    {
        textMesh.text = array[Random.Range(0, array.Length - 1)];
    }

}
