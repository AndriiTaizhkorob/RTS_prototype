using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100;
    public int result;

    public GameObject judge;

    void Start()
    {
        judge = GameObject.Find("EventManager");
    }

    void Update()
    {
        if (health <= 0)
        {
            if (gameObject.name == "EnemyMainBase")
            {
                result = 1;
                judge.GetComponent<EventsAndInteractions>().victory(result);
                Destroy(gameObject);
            }
            else if(gameObject.name == "PlayerMainBase")
            {
                result = 2;
                judge.GetComponent<EventsAndInteractions>().victory(result);
                Destroy(gameObject);
            }

            else
            {
                Destroy(gameObject);
            }
            
        }
    }

    public void DealDamage(float damage)
    {
        health -= damage;
    }
}
