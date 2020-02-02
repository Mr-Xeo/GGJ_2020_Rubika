using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public Screen_Shake InstanciateScreenshake;
    Machine[] machineArray;

    float secMaxExplo = 2;
    float secMinExplo = 1;

    float machineDmg = 25;

    public bool isEveryMachineFullLife;

    void Start()
    {
        GameObject[] MachinesGo = GameObject.FindGameObjectsWithTag("Machine");
        machineArray = new Machine[MachinesGo.Length];
        for (int i = 0; i < MachinesGo.Length; i++)
        {
            machineArray[i] = MachinesGo[i].GetComponent<Machine>();
        }


        InvokeRepeating("Re", 0, 5);
    }

    void Update()
    {
        CheckMachinesFullLife();
    }

    void CheckMachinesFullLife()
    {
        float[] MachineLifes = new float[machineArray.Length];

        for (int i = 0; i < machineArray.Length; i++)
        {
            MachineLifes[i] = machineArray[i].machineLife;
        }

        var getLowestValue = Mathf.Min(MachineLifes);

        if(getLowestValue == Machine.machineLifeMax)
        {
            isEveryMachineFullLife = true;
        }

        else
        {
            isEveryMachineFullLife = false;
        }
    }

    IEnumerator AttackCoroutine()
    {
        float secBeforeExplo = Random.Range(secMinExplo, secMaxExplo);
        yield return new WaitForSeconds(secBeforeExplo);

        int RandomMachineChoose = Random.Range(0, machineArray.Length - 1);
        Machine goMachine = machineArray[RandomMachineChoose];

        goMachine.machineLife -= machineDmg;
        InstanciateScreenshake.shakeDuration = 1;
    }

    void Re()
    {
        StartCoroutine(AttackCoroutine());
    }
}
