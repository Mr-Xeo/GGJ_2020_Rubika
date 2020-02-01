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
    public Collider2D actionCollider;
    GameObject grabbedObject;

    //Grab
    bool isLifting;
    bool isObjectGrabbed;
    bool liftNerf;

    //Action / Repair
    bool isRepair;

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

        if(isObjectGrabbed)
        {
            grabbedObject.transform.rotation = Quaternion.identity;
        }
        if(playerBindLiftObj)
        {
            PlayerGrab();
        }
    }


    //---------
    void FixedUpdate()
    {
        PlayerMovement();

        PlayerUse();
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
        playerBindLiftObj = Input.GetButtonDown("Action2");
        playerBindCamera = Input.GetButton("Action3");
        playerBindStart = Input.GetButton("Start");
    }

    void PlayerGrab()
    {
        if(!isObjectGrabbed)
        {
            ContactFilter2D filter = new ContactFilter2D();
            filter.SetLayerMask(LayerMask.GetMask("Tool"));
            filter.useTriggers = true;
            List<Collider2D> colliders = new List<Collider2D>();
            Physics2D.OverlapCollider(actionCollider, filter, colliders);

            if (colliders.Count > 0)
            {
                isObjectGrabbed = true;
                colliders[0].gameObject.transform.parent = actionCollider.transform;
                grabbedObject = colliders[0].gameObject;
                grabbedObject.transform.position = actionCollider.transform.position;
                grabbedObject.transform.rotation = Quaternion.identity;
            }
        }
        else
        {
            grabbedObject.transform.parent = null;
            grabbedObject = null;
            isObjectGrabbed = false;
        }
    }       

    void PlayerUse()
    {
        if (playerBindUseObj)
        {
            isRepair = true;
        }

        else if (!playerBindUseObj)
        {
            isRepair = false;
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {

        #region Repair

        if (other.gameObject.tag == "Machine" && isRepair)
        {
            //Add Life
            print("Machine repairing");
        }

        #endregion
    }
}
