using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 1;

    public new Camera camera;

    public Vector3 currentPosition, targetPosition;

    public bool isControled, isMoving;

    public string unitName, unitHP, unitCooldown;

    private GameObject reciver;

    void Start()
    {
        camera = GameObject.FindObjectOfType<Camera>();

        reciver = GameObject.Find("IngameUI");

        currentPosition = transform.position;
        targetPosition = transform.position;
    }

    void Update()
    {
        gameObject.GetComponent<PlayerBehaviour>().PositionData(currentPosition, targetPosition);

        if (Input.GetMouseButtonDown(0))
        {
            Activation();
        }

        if (isControled)
        {
            unitName = gameObject.name;
            unitHP = "Health: " + gameObject.GetComponent<Health>().health;

            if (gameObject.GetComponent<PlayerBehaviour>().cooldown > 0)
            {
                unitCooldown = "Cooldown: " + Math.Round(gameObject.GetComponent<PlayerBehaviour>().cooldown);
            }
            else
            {
                unitCooldown = "Cooldown: Ready";
            }

            reciver.GetComponent<UnitInfo>().reciveInfo(unitName, unitHP, unitCooldown);
        }

        if (isControled == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                CheckMouse();
            }
            Moving();
        }
    }

    void Activation()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == gameObject.transform)
            {
                isControled = true;
            }
            else 
            { 
                isControled = false;
            }
        }
    }

    public void CheckMouse()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            targetPosition = hit.point;
        }
    }
    public void Moving()
    {
        if (currentPosition != targetPosition)
        {
            isMoving = true;
        }
        else if (currentPosition == targetPosition)
        { 
            isMoving = false;  
        }

        gameObject.GetComponent<PlayerBehaviour>().Inconsistency(isMoving);


        Vector3 newPosition = Vector3.MoveTowards(currentPosition, targetPosition, Time.deltaTime * moveSpeed);
        currentPosition = newPosition;

        transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
    }
}
