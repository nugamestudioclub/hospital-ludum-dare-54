using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TipCardSwipeIn : MonoBehaviour
{
    [SerializeField] private Notecard _notecard;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;

    void OnEnable()
    {
        transform.position = _startPoint.position;
    }

    void Update()
    {
        if (_notecard._showNotecard == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _endPoint.position, 200f * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPoint.position, 200f * Time.deltaTime);
            if(Vector3.Distance(transform.position, _startPoint.position) < 0.1)
            {
                _notecard.inView = false;
            }
        }
    }
}
