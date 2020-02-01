using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Player 
    [Header("Player variables")]
    public GameObject playerGo;
    public Rigidbody2D playerRb;
    public Vector3 playerControl;
    public float playerSpeed = 500;
    private float controllerDeadzone = 0.25f;

    [Header("Collider")]
    public Collider2D grabCollider;
    bool isLifting;
    bool isObjectGrabbed;
    bool liftNerf;


    //Player inputs
    [Header("Player inputs")]
    [Range(-1f, 1f)]
    public float playerBindHorizontal;
    [Range(-1f, 1f)]
    public float playerBindVertical;

    public bool playerBindUseObj;
    public bool playerBindLiftObj;
    public bool playerBindCamera;
    public bool playerBindStart;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    //---------
    void Update()
    {
        GetPlayerController();

        PlayerGrab();

        print(isObjectGrabbed);
    }


    //---------
    void FixedUpdate()
    {
        PlayerMovement();
    }




    void PlayerMovement()
    {
        playerControl = new Vector3(playerBindHorizontal, playerBindVertical);
        if (playerControl.magnitude < controllerDeadzone)
        {
            playerControl = Vector2.zero;
        }

        playerRb.velocity = new Vector2(playerBindHorizontal * playerSpeed * Time.deltaTime, playerBindVertical * playerSpeed * Time.deltaTime);
    }

    void GetPlayerController()
    {
        //Left stick
        playerBindHorizontal = Input.GetAxis("Horizontal");
        playerBindVertical = Input.GetAxis("Vertical");


        //Buttons
        playerBindUseObj = Input.GetButton("Action1");
        playerBindLiftObj = Input.GetButton("Action2");
        playerBindCamera = Input.GetButton("Action3");
        playerBindStart = Input.GetButton("Start");
    }

    void PlayerGrab()
    {
        //grab nerf
        if(playerBindLiftObj && !liftNerf)
        {
            StartCoroutine(PlayerLiftingCoroutine());
            liftNerf = true;
        }

        if(!playerBindLiftObj)
        {
            liftNerf = false;
        }


        //grabbing item
        if (isLifting && !isObjectGrabbed)
        {
            isObjectGrabbed = true;
        }

        else if (isLifting && isObjectGrabbed)
        {
            isObjectGrabbed = false;
        }

    }       

    void OnTriggerStay2D(Collider2D other)
    {
        print(other.gameObject.name);    
        if(isObjectGrabbed)
        {
            other.gameObject.transform.parent = grabCollider.transform;
        }

        else if (!isObjectGrabbed)
        {
            other.gameObject.transform.parent = null;
            isObjectGrabbed = false;
        }
    }


    IEnumerator PlayerLiftingCoroutine()
    {
        isLifting = true;
        yield return 0;
        yield return 0;
        yield return 0;
        yield return 0;
        isLifting = false;
    }
}
