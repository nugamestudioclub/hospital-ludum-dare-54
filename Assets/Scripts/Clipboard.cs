using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clipboard : MonoBehaviour
{
    
    [SerializeField] private GameObject _clipboard;

    [HideInInspector]
    public bool _showClipboard = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _showClipboard = !_showClipboard;
        }
    }
}
