using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer;
    public float bombingCD;
    public Text timer1;
    public Color timer1Color;

    // Start is called before the first frame update
    void Start()
    {
        timer = 60f;
        bombingCD = 10f;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer < 0)
        {
            BombingTime();
        }
        else
        {
            timer -= Time.deltaTime;
            timer1.text = timer.ToString("0");
        }
    }
    void BombingTime()
    {

        {
            if (bombingCD < 0)
            {

            }
            else
            {
                bombingCD -= Time.deltaTime;
                timer1.text = bombingCD.ToString("0");
                timer1.color = timer1Color;
            }
        }
    }
}
