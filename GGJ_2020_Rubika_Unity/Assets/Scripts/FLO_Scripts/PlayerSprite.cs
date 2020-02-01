using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    public Player castPlayerScript;
    public bool isIdle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotationAngle = castPlayerScript.playerControl;

        if (rotationAngle.y == 0 && rotationAngle.x == 0)
        {
            isIdle = true; 
        }

        else
        {
            isIdle = false;
        }

        float aim_angle = Mathf.Atan2(rotationAngle.y, rotationAngle.x) * Mathf.Rad2Deg;

        if(!isIdle)
        {
            transform.rotation = Quaternion.AngleAxis(aim_angle, Vector3.forward);
        }
    }
}
