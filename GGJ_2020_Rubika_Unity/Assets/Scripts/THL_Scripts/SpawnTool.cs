using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTool : MonoBehaviour
{
    public GameObject[] objects;

    Vector3 pos;

    private void Start()
    {
        int rand = Random.Range(0, objects.Length);
        pos = new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(objects[rand], pos, Quaternion.identity);
    }


}