using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    //Life vars
    public static float machineLifeMax = 200;
    public float machineLife = 100;
    float lifeRegen = 50;
    [Range(0, 1)]
    public float machineLifeUi;

    public Player castPlayerScript;


    void Start()
    {
        
    }

    void Update()
    {       
        if(castPlayerScript.isRepair && machineLife < machineLifeMax)
        {
            machineLife += lifeRegen * Time.deltaTime;
        }

        if(machineLife > machineLifeMax)
        {
            machineLife = machineLifeMax;
        }

        machineLifeUi = (machineLife - 0) / (machineLifeMax - 0);
    }
}
