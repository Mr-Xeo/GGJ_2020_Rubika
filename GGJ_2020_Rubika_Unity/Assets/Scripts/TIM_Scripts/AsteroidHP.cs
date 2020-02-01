using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHP : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Ship")
        {
            Debug.Log("hello");
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
