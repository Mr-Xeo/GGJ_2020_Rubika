using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Player 
    [Header("Player variables")]
    public GameObject playerGo;
    public Vector3 playerControl;
    public float playerSpeed = 5;

    //Player inputs
    [Header("Player inputs")]
    [Range(-1f, 1f)]
    public float playerBindHorizontal;
    [Range(-1f, 1f)]
    public float playerBindVertical;

    public bool playerBindUseObj;
    public bool playerBindLiftObj;
    public bool playerBindStart;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerController();

        PlayerMovement();
    }

    void GetPlayerController()
    {
        //Left stick
        playerBindHorizontal = Input.GetAxis("Horizontal");
        playerBindVertical = Input.GetAxis("Vertical");

        //Buttons
        playerBindUseObj = Input.GetButton("Action1");
        playerBindLiftObj = Input.GetButton("Action2");
        playerBindStart = Input.GetButton("Start");

        //-----
        //AJOUTER BOUTON Y
    }

    void PlayerMovement()
    {
        playerControl = new Vector3(playerBindHorizontal * playerSpeed, playerBindVertical * playerSpeed);

        playerGo.transform.position = playerGo.transform.position + playerControl * Time.deltaTime;
    }
}
