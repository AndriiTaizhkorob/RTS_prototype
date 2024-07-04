using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInfo : MonoBehaviour
{
    public new Camera camera;

    public string unitName, unitHP, unitCooldown;

    private new GameObject reciver;

    public bool isControled;

    public GameObject child1;

    void Start()
    {
        child1 = gameObject.transform.GetChild(0).gameObject;

        camera = GameObject.FindObjectOfType<Camera>();

        reciver = GameObject.Find("IngameUI");
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Activation();
        }

        if (isControled)
        {
            unitName = gameObject.name;
            unitHP = "Health: " + gameObject.GetComponent<Health>().health;
            unitCooldown = "None";

            reciver.GetComponent<UnitInfo>().reciveInfo(unitName, unitHP, unitCooldown);
        }
    }

    void Activation()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == child1.transform)
            {
                isControled = true;
            }
            else
            {
                isControled = false;
            }
        }
    }
}
