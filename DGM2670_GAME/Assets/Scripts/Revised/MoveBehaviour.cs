using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveBehaviour : GroundCheckBehaviour
{
    private Rigidbody playerRB;
    private GameObject playerGun;

    public Vector3 inputVector;

    public float currentSpeed,
        defaultSpeed = 4f,
        speedySpeed = 6f,
        jumpForce = 100f,
        jumpCooldown = 0.1f,
        timeSinceJump,
        gravityMultiplier = 1f,
        gravityUp = 1.5f,
        gravityDown = 0.5f;
    public int jumpCount = 1, jumpCountMax = 1;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }
    
    void ChangeGroundedStatus()
    {
        IsGrounded = false;
        Debug.Log("Invoked");
    }

    void FixedUpdate()
    {
        playerRB.AddForce(inputVector);
    }
    void Update()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal") * currentSpeed, Physics.gravity.y + gravityMultiplier,Input.GetAxis("Vertical") * currentSpeed);
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
        


        if (Input.GetKey(KeyCode.LeftShift))
        {
          currentSpeed = speedySpeed;
        } 
        else
        { 
          currentSpeed = defaultSpeed;
        }
    }
}
