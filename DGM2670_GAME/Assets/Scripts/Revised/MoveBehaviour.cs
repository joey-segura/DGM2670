using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveBehaviour : GroundCheckBehaviour
{
   
    public Camera cam;
    private Rigidbody playerRB;
    private GameObject playerGun;

    public Vector3 inputVector;

    public float currentSpeed,
        defaultSpeed = 4f,
        speedySpeed = 6f,
        jumpForce = 100f,
        jumpCooldown = 0.1f,
        timeSinceJump,
        gravity,
        increasedGravity = 1f,
        decreasedGravity = 0.5f;
    public int jumpCount = 1, jumpCountMax = 1;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();
    }

    void FixedUpdate()
    {
        playerRB.velocity = inputVector;
        
        
        if (IsGrounded == true)
        {
            gravity = 1f;
        }
        else
        {
            gravity = 10f;
        }
    }

    void ChangeGroundedStatus()
    {
        IsGrounded = false;
        Debug.Log("Invoked");
    }
    
    void Update()
    {

        inputVector = new Vector3(Input.GetAxis("Horizontal") * currentSpeed, -gravity,Input.GetAxis("Vertical") * currentSpeed);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
        
        //Handle jump.

        //timeSinceJump += Time.deltaTime;
        
        //&& timeSinceJump > jumpCooldown
        if (Input.GetButtonDown("Jump") && IsGrounded == true)
        {
            inputVector.y = jumpForce;
            Invoke("ChangeGroundedStatus", 0.1f);
            //IsGrounded = false;
            //timeSinceJump = 0;
        }

        
        //if (inputVector.y > 0)
        {
            //gravity = decreasedGravity;
        }
        //else if (inputVector.y < 0)
        {
            //gravity = increasedGravity;
        }

        //Toggle Sprinting.
        
         if (Input.GetKey(KeyCode.LeftShift))
         {
          currentSpeed = speedySpeed;
         } 
         else
         { 
          currentSpeed = defaultSpeed;
         }

        //Exit map respawn.
        
         //if (location.y < 3)
        //{ 
         //FindObjectOfType<GameManager>().Respawn();
        //} 
    }
}
