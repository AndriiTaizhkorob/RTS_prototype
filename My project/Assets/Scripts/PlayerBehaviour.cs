using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public LayerMask enemy;

    public GameObject nearestEnemy, particleEffect;
    public GameObject[] allEnemys;
    ParticleSystem fireEffect;
    AudioSource gunShot;

    public float sightDistance = 8f;
    public float attackDistance = 5f;
    public float damage = 20;
    public float cooldown = 0f;
    public float cooldownTime = 2f;

    private float theClosest = 0;
    private float theCurrent = 0;

    public bool inSightRange, inAttackRange, present;

    public Vector3 targetPos, currentPos, lookDirection;

    void Start()
    {
        cooldown = cooldownTime;

        particleEffect = gameObject.transform.GetChild(0).gameObject;

        fireEffect = particleEffect.GetComponent<ParticleSystem>();
        gunShot = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        cooldown -= Time.deltaTime;

        lookDirection = new Vector3(targetPos.x, 1, targetPos.z);

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

        //Check of enemys's unit presence.
        inSightRange = Physics.CheckSphere(currentPos, sightDistance, enemy);
        inAttackRange = Physics.CheckSphere(currentPos, attackDistance, enemy);

        
        if (inSightRange)
        {
            transform.LookAt(nearestEnemy.transform.position);
        }
        else
        {
            transform.LookAt(lookDirection);
        }

        //Behaviour conditions
        if (inSightRange && inAttackRange && cooldown <= 0 && !present)
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
        fireEffect.Play();
        gunShot.Play();
        nearestEnemy.GetComponent<Health>().DealDamage(damage);
        cooldown = cooldownTime;
    }
}
