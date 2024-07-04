using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public LayerMask enemy;

    public GameObject nearestEnemy;
    public GameObject[] allEnemys;

    public float sightDistance = 8f;
    public float attackDistance = 5f;
    public float damage = 20;
    public float cooldown = 0f;
    public float cooldownTime = 2f;

    private float theClosest = 0;
    private float theCurrent = 0;

    public bool inSightRange, inAttackRange, present;

    public Vector3 enemyPosition;

    private Vector3 currentPos;
    private Vector3 targetPos;

    void Start()
    {
        cooldown = cooldownTime;
    }

    void Update()
    {
        cooldown -= Time.deltaTime;

        //Identifies the nearest enemy in sight and updates the list.
        if (Physics.CheckSphere(currentPos, sightDistance))
        {
            allEnemys = GameObject.FindGameObjectsWithTag("Enemy");
            nearestEnemy = allEnemys[0];
            theClosest = Vector3.Distance(currentPos, nearestEnemy.transform.position);

            for (int i = 1; i < allEnemys.Length; i++)
            {
                theCurrent = Vector3.Distance(currentPos, allEnemys[i].transform.position);

                if (theCurrent < theClosest)
                {
                    nearestEnemy = allEnemys[i];
                    theClosest = theCurrent;
                }
            }
        }

        targetPos = nearestEnemy.transform.position;

        //Check of player's unit presence.
        inSightRange = Physics.CheckSphere(currentPos, sightDistance, enemy);
        inAttackRange = Physics.CheckSphere(currentPos, attackDistance, enemy);

        //Behaviour conditions
        if (inSightRange && !inAttackRange && !present)
        {
            gameObject.GetComponent<CharacterMovement>().Moving(enemyPosition);
        }
        else if (inSightRange && inAttackRange && cooldown <= 0 && !present)
        {
            Attacking();
        }
    }

    //Inconsistency check.
    public void Inconsistency(bool isMoving) 
    {
        present = isMoving;
    }

    //Getting needed data form CharacterMovement.
    public void PositionData(Vector3 currentPosition, Vector3 targetPosition)
    {
        currentPos = currentPosition;
        targetPos = targetPosition;
    }

    //Attack of the enemy unit
    private void Attacking()
    {
        nearestEnemy.GetComponent<Health>().DealDamage(damage);
        cooldown = cooldownTime;
    }
}
