using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clipboard : MonoBehaviour
{
    [SerializeField] private GameObject _clipboard;

    private bool _showClipboard = false;

    private void Start()
    {
        _clipboard.SetActive(_showClipboard);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _showClipboard = !_showClipboard;
            _clipboard.SetActive(_showClipboard);
        }
        
    }
}
