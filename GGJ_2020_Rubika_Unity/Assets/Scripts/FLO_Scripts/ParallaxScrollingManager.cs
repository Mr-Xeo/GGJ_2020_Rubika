using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrollingManager : MonoBehaviour
{
    private float picLength;
    private float picSpeed;
    public float parallaxSpeed;

    void Start()
    {
        picLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
            picSpeed = -parallaxSpeed * Time.fixedTime;
            transform.position = new Vector2(Mathf.Repeat(picSpeed, picLength), transform.position.y);
    }
}
