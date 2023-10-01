using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notecard : MonoBehaviour
{
    [SerializeField] private GameObject _notecard;

    [HideInInspector]
    public bool _showNotecard = false;

    // Moves card on screen
    public void showNotecard()
    {
        _showNotecard = true;
    }

    // Moves card off screen
    public void removeNotecard()
    {
        _showNotecard = false;
    }
}