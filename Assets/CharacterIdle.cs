using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class CharacterIdle : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(Mathf.Sin(Time.deltaTime) + 1, Mathf.Sin(Time.deltaTime) + 1, 0f);
    }
}
