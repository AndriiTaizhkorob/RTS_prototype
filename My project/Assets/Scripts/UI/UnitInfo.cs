using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnitInfo : MonoBehaviour
{

    public TextMeshProUGUI unitID, unitHealth, unitCuldown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reciveInfo(string unitName, string unitHP, string unitCooldown) 
    { 
        unitID.text = unitName;
        unitHealth.text = unitHP;
        unitCuldown.text = unitCooldown;
    }
}
