using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machine : MonoBehaviour
{
    //Life vars
    public static float machineLifeMax = 200;
    public float machineLife = 200;
    float lifeRegen = 50;
    [Range(0, 1)]
    public float machineLifeUi;
    public GameObject bubullePrefab;
    public Player castPlayerScript;

    public GameObject tool1Display;
    public GameObject tool2Display;
    public GameObject tool3Display;

    string ChoosedTool;
    string T1 = "Tool1";
    string T2 = "Tool2";
    string T3 = "Tool3";

    bool asChoosedTool;

    GameObject currentBubulle;

    void Start()
    {

    }

    void Update()
    {
        //Normalization
        machineLifeUi = (machineLife - 0) / (machineLifeMax - 0);

        // Life Regen
        if (castPlayerScript.currentMachine == this && machineLife < machineLifeMax && ChoosedTool == getChildrenName.goChildName)
        {
            machineLife += lifeRegen * Time.deltaTime;
        }

        // si plus que max, then max
        if(machineLife > machineLifeMax)
        {
            machineLife = machineLifeMax;
        }

        //si max life, peux à nouveau choisir un outil (pour le prochain dmg)
        if(machineLife == machineLifeMax)
        {
            asChoosedTool = false;
            Destroy(currentBubulle);
            currentBubulle = null;
        }
 

        if(machineLife < machineLifeMax && !asChoosedTool)
        {
            ChooseTool();
            asChoosedTool = true;
        }
    }


    void ChooseTool()
    {
        int rdTool = Random.Range(0, 3);
        currentBubulle = Instantiate(bubullePrefab, transform.position, Quaternion.identity);
        switch (rdTool)
        {
            case 0:

                ChoosedTool = T1;
                Instantiate(tool1Display, currentBubulle.transform.GetChild(1).position, Quaternion.identity, currentBubulle.transform);
                break;

            case 1:

                ChoosedTool = T2;
                Instantiate(tool2Display, currentBubulle.transform.GetChild(1).position, Quaternion.identity, currentBubulle.transform);
                break;

            case 2:

                ChoosedTool = T3;
                Instantiate(tool3Display, currentBubulle.transform.GetChild(1).position, Quaternion.identity, currentBubulle.transform);
                break;
        }
    }
}
