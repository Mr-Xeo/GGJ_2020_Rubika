using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public float startHealth = 100;
    public float health;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Asteroid")
        {
            TakeDamage(25f);
        }
    }
    public void TakeDamage(float Amount)
    {
        health -= Amount;
        if (health<=0)
        {
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
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
