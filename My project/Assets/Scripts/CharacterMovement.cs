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

    void Start()
    {
        currentPosition = transform.position;
        targetPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            CheckMouse();
        }
        Moving();
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
    private void Moving()
    {
        Vector3 lerpPosition = Vector3.MoveTowards(currentPosition, targetPosition, Time.deltaTime * moveSpeed);
        currentPosition = lerpPosition;

        transform.position = new Vector3(lerpPosition.x, transform.position.y, lerpPosition.z);
    }
}
