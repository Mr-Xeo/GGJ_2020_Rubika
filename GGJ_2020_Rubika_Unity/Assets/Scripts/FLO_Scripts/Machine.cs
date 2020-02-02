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
    bool castReparation;

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

        //Normalization
        machineLifeUi = (machineLife - 0) / (machineLifeMax - 0);

        //cast reparation
        if (machineLife < machineLifeMax)
        {
            castReparation = true;
        }

        if (castReparation)
        {
            ChooseTool();
        }
    }


    void ChooseTool()
    {
        castReparation = false;

        int rdTool = Random.Range(0, 2);

        switch (rdTool)
        {
            case 0:
                
                //choose tool 1

                break;

            case 1:

                break;

            case 2:

                break;

            default:
                print("failed");
                break;
        }
    }
}
