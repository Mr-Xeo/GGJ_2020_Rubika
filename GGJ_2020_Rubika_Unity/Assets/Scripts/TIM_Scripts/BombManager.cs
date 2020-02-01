using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombManager : MonoBehaviour
{
    public float timer;
    public float bombingCD;
    public Text timer1;
    public Color timer1Color;
    public GameObject[] bombs;
    public DamageScript damageScript;
    public Player playerScript;

    private int bombScore;

    // Start is called before the first frame update
    void Start()
    {
        timer = 60f;
        bombingCD = 10f;
        bombScore = 0;
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
        if (bombingCD < 0)
        {
            if ((damageScript.isEveryMachineFullLife == true)&&(playerScript.activateLever==true))// il n'y a plus de dommages && la bombe est lancée
            {
                bombScore++;
                bombs[bombScore].SetActive(true);

                if (bombScore == 3)
                {
                    FindObjectOfType<GameManager>().WinGame();
                }
                else
                {
                timer = 60f;
                bombingCD = 10f;
                }
            }

            else
            {
                FindObjectOfType<GameManager>().EndGame();
            }
        }

        else
        {
            bombingCD -= Time.deltaTime;
            timer1.text = bombingCD.ToString("0");
            timer1.color = timer1Color;
        }
    }
}




