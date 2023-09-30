using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SwipeIn : MonoBehaviour
{

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
        transform.position = Vector3.MoveTowards(transform.position, _endPoint.position, 1000f * Time.deltaTime);
    }
}
