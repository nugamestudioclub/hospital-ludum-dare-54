using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeTutorialText : MonoBehaviour
{
 
    [SerializeField] private TextMeshProUGUI _tutorialText;
    [SerializeField] private TextMeshProUGUI _cardNumberText;
    [SerializeField] private string[] _instructions;

    [HideInInspector]
    public int textIndex = 0;

    private void Start()
    {
        SetInstructionText();
    }

    public void IncreaseIndex()
    {
        if(textIndex < _instructions.Length - 1)
        {
            textIndex++;
        }
        else
        {
            textIndex = 0;
        }
        SetInstructionText();
    }

    public void DecreaseIndex()
    {
        if(textIndex > 0)
        {
            textIndex--;
        }
        else
        {
            textIndex = _instructions.Length - 1;
        }

        SetInstructionText();
    }

    private void SetInstructionText()
    {
        _tutorialText.text = _instructions[textIndex];
        _cardNumberText.text = textIndex + 1 + "/" + _instructions.Length;
    }

}
