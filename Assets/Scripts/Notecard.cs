 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* To use in a script, just make a serialized field private GameObject note, and attach the Note Card Popup to it. 
* Then, you can just call note.GetComponent<Notecard>().showNotecard("text here") to show that text and 
* note.GetComponent<Notecard>().removeNotecard() to get rid of the notecard.
*/
public class Notecard : MonoBehaviour
{
    [SerializeField] private GameObject note;
    [SerializeField] private GameObject _notecard;
    public TMPro.TextMeshProUGUI text;

    [HideInInspector]
    public bool _showNotecard = false;
    [SerializeField]
    public bool inView = false;
    // Moves card on screen
    public void showNotecard(string input)
    {
        text.text = input;
        _showNotecard = true;
        inView = true;
    }

    // Moves card off screen
    public void removeNotecard()
    {
        _showNotecard = false;
    }
}