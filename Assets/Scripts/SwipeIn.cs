using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SwipeIn : MonoBehaviour
{
    [SerializeField] private Clipboard _clipboard;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;



    // Start is called before the first frame update
    void OnEnable()
    {
        transform.position = _startPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_clipboard._showClipboard == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _endPoint.position, 5000f * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPoint.position, 5000f * Time.deltaTime);
        }
    }
}
