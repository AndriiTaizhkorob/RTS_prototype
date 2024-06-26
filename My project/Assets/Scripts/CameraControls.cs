using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontrols : MonoBehaviour
{
    public float camSpeed = 1.0f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(camSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, camSpeed * Input.GetAxis("Vertical") * Time.deltaTime, Space.World);
    }
}
