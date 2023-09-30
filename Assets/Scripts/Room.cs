using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private RoomSystem.Patient currentPatient;
    private bool empty;
    private float countDownTime;

    public bool isOpen()
    {
        return empty;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
