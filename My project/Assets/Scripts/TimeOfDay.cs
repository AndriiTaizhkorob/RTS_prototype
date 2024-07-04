using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDay : MonoBehaviour
{


    void Start()
    {

    }

    void Update()
    {
        transform.Rotate( 0.5f * Time.deltaTime, transform.rotation.y, transform.rotation.z);
    }
}
