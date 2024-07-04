using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LooseCondition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void loose()
    {
        gameObject.SetActive(true);
    }
}
