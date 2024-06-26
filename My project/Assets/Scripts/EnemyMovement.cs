using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public LayerMask Player;

    public GameObject nearestPlayer;
    public GameObject[] allPlayers;

    public float moveSpeed = 1f;
    public float sightDistance = 8f;
    public float attackDistance = 5f;
    public float damage = 20f;
    public float cooldown = 0f;
    public float cooldownTime = 2f;

    private float theClosest = 0;
    private float theCurrent = 0;

    private Vector3 currentPosition;
    private Vector3 targetPosition;

    public bool inSightRange, inAttackRange;

    void Start()
    {
        currentPosition = transform.position;
        targetPosition = transform.position;
        cooldown = cooldownTime;
    }

    void Update()
    {
        transform.LookAt(targetPosition);
        cooldown -= Time.deltaTime;

        if (Physics.CheckSphere(currentPosition, sightDistance)) 
        {
            allPlayers = GameObject.FindGameObjectsWithTag("Player");
            nearestPlayer = allPlayers[0];
            theClosest = Vector3.Distance(currentPosition, nearestPlayer.transform.position);

            for (int i = 1; i < allPlayers.Length; i++)
            {
                theCurrent = Vector3.Distance(currentPosition, allPlayers[i].transform.position);

                if (theCurrent < theClosest)
                {
                    nearestPlayer = allPlayers[i];
                    theClosest = theCurrent;
                }
            }
        }

        targetPosition = nearestPlayer.transform.position;

        inSightRange = Physics.CheckSphere(currentPosition, sightDistance, Player);
        inAttackRange = Physics.CheckSphere(currentPosition, attackDistance, Player);

        if (inSightRange && !inAttackRange) 
        {
            Moving();
        }
        else if (inSightRange && inAttackRange && cooldown <= 0)
        {
            Attacking();
        }
        else
        {
            targetPosition = transform.position;
        }
    }

    private void Moving()
    {
        Vector3 lerpPosition = Vector3.MoveTowards(currentPosition, targetPosition, Time.deltaTime * moveSpeed);
        currentPosition = lerpPosition;

        transform.position = new Vector3(lerpPosition.x, transform.position.y, lerpPosition.z);
    }

    private void Attacking()
    {
        nearestPlayer.GetComponent<Health>().DealDamage(damage);
        cooldown = cooldownTime;
    }
}
