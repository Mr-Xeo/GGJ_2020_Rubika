using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural : MonoBehaviour
{
    public GameObject asteroid;
    public int randInt;
    Vector3 spawnerPos;
    void Spawn()
    {
        spawnerPos = GameObject.Find("Spawner").transform.position;
        randInt = Random.Range(0, 3);
        for (int i = 0; i < 3; i++)
        {
            var position = new Vector3(Random.Range(-8, 8), spawnerPos.y, 0);
            Instantiate(asteroid, position, Quaternion.identity);
        }
    }

 /*   IEnumerator SpawnAsteroid()
    {
        yield return new WaitForSeconds(1f);
        Spawn();
        
    }*/
    
    void Start()
    {
        InvokeRepeating("Spawn", 2.0f, 5.0f);
    }


    void Update()
    {
        
    }
}
