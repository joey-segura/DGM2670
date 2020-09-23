using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveBehaviour : MonoBehaviour
{
   
    public Camera cam;
    private Rigidbody playerRB;
    private GameObject playerGun;

    public Vector3 inputVector;

    public float currentSpeed,
        defaultSpeed = 4f,
        speedySpeed = 6f,
        jumpForce = 20f,
        jumpCooldown = 0.85f,
        timeSinceJump,
        distToGround,
        gravity = 10f,
        increasedGravity = 1f,
        decreasedGravity = 0.5f;
    public int jumpCount = 1, jumpCountMax = 1;
    
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();

        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    void FixedUpdate()
    {
        playerRB.velocity = inputVector;
    }
    
    void Update()
    {

        inputVector = new Vector3(Input.GetAxis("Horizontal") * currentSpeed, -gravity,Input.GetAxis("Vertical") * currentSpeed);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
        
        //Handle jump.

        timeSinceJump += Time.deltaTime;
        
        if (Input.GetButtonDown("Jump") && timeSinceJump > jumpCooldown)
        {
            inputVector.y = jumpForce;
            timeSinceJump = 0;
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
        { 
         FindObjectOfType<GameManager>().Respawn();
        } 
    }
}
