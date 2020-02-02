using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public Screen_Shake InstanciateScreenshake;
    public Vector2 tentacouilleOffset;
    public GameObject tentacouillePrefab;
    public GameObject tentacouilleFX;
    public float tentacouilleSpeed;
    public float spawnInterval;
    Machine[] machineArray;

    float secMaxExplo = 5;
    float secMinExplo = 2;

    float machineDmg = 25;

    GameObject currentTentacouille;

    public bool isEveryMachineFullLife;

    BombManager bombManager;

    void Start()
    {
        bombManager = GetComponent<BombManager>();
        GameObject[] MachinesGo = GameObject.FindGameObjectsWithTag("Machine");
        machineArray = new Machine[MachinesGo.Length];
        for (int i = 0; i < MachinesGo.Length; i++)
        {
            machineArray[i] = MachinesGo[i].GetComponent<Machine>();
        }
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
        int RandomMachineChoose = Random.Range(0, machineArray.Length - 1);
        Machine goMachine = machineArray[RandomMachineChoose];

        float secBeforeExplo = Random.Range(secMinExplo, secMaxExplo);
        yield return new WaitForSeconds(secBeforeExplo);

        currentTentacouille = Instantiate(tentacouillePrefab, (Vector2)goMachine.transform.position + tentacouilleOffset, Quaternion.identity);

        Vector2 direction = goMachine.transform.position - currentTentacouille.transform.position;
        direction.Normalize();
        while (Vector2.Distance(currentTentacouille.transform.position, goMachine.transform.position) > 0.2f)
        {
            currentTentacouille.transform.position += (Vector3)direction * Time.deltaTime * tentacouilleSpeed;
            yield return new WaitForEndOfFrame();
        }
        Destroy(currentTentacouille);
        Destroy(Instantiate(tentacouilleFX, goMachine.transform.position, Quaternion.identity), 0.6f);



        goMachine.machineLife -= machineDmg;
        InstanciateScreenshake.shakeDuration = 1;
        if(goMachine.machineLife < 0)
        {
            goMachine.machineLife = 0;
        }
    }

    public IEnumerator SpawnTentacouille()
    {
        while (bombManager.bombingCD == bombManager.maxBombingTime)
        {
            StartCoroutine(AttackCoroutine());
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
