using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Spawner : MonoBehaviour
{
    public GameObject[] gunnerPrefab;
    public float spawnTime = 8f;
    public float spawnCooldown = 0f;
    public new Camera camera;

    public bool isControled;

    private Vector3 spawnPosition;

    public GameObject child1;
    AudioSource spawn;

    public string unitName, unitHP, unitCooldown;

    private GameObject reciver;

    void Start()
    {
        child1 = gameObject.transform.GetChild(0).gameObject;

        reciver = GameObject.Find("IngameUI");

        camera = GameObject.FindObjectOfType<Camera>();
        spawn = gameObject.GetComponent<AudioSource>();

    spawnCooldown = spawnTime;
        spawnPosition = new Vector3(transform.position.x, 1f, transform.position.z - 2f);
    }


    void Update()
    {
        spawnCooldown -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Activation();
        }

        if (isControled)
        {
            unitName = gameObject.name;
            unitHP = "Health: " + gameObject.GetComponent<Health>().health;

            if (spawnCooldown > 0)
            {
                unitCooldown = "Cooldown: " + Math.Round(spawnCooldown);
            }
            else
            {
                unitCooldown = "Cooldown: Ready";
            }

            reciver.GetComponent<UnitInfo>().reciveInfo(unitName, unitHP, unitCooldown);
        }

        if (spawnCooldown <= 0f && isControled)
        {

            if (Input.GetKeyDown("g"))
            { 
                spawnGunner();
            }
        }
    }

    public void spawnGunner()
    {
        spawn.Play();
        Instantiate(gunnerPrefab[0], spawnPosition, transform.rotation);
        spawnCooldown = spawnTime;
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
