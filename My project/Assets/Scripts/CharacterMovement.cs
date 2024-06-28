using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 1;

    public new Camera camera;

    Vector3 currentPosition;

    public Vector3 targetPosition;

    public bool isControled, isMoving;

    void Start()
    {
        camera = GameObject.FindObjectOfType<Camera>();

        currentPosition = transform.position;
        targetPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Activation();
        }

        if (isControled == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                CheckMouse();
            }
            Moving(targetPosition);
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
    public void Moving(Vector3 enemyPosition)
    {
        if (currentPosition != targetPosition)
        {
            isMoving = true;
            gameObject.GetComponent<PlayerBehaviour>().Inconsistency(isMoving);
        }
        else if (currentPosition == targetPosition)
        { 
            isMoving = false;
            targetPosition = enemyPosition;
        }

        Vector3 newPosition = Vector3.MoveTowards(currentPosition, targetPosition, Time.deltaTime * moveSpeed);
        currentPosition = newPosition;

        transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
    }
}
