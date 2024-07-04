using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100;
    public int result;

    void Start()
    {
        
    }

    void Update()
    {
        if (health <= 0)
        {
            if (gameObject.name == "EnemyMainBase")
            {
                result = 1;
                GetComponent<EventsAndInteractions>().victory(result);
                Destroy(gameObject);
            }
            else if(gameObject.name == "MainBase")
            {
                result = 2;
                GetComponent<EventsAndInteractions>().victory(result);
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
