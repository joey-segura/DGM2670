using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class AT_PlayerMoveBehaviour : MonoBehaviour

{
    public CharacterController cntrl;

    private Vector3 movement;

    public float currentSpeed,
        defaultSpeed = 4f,
        speedySpeed = 6f,
        jumpForce = 11f,
        gravity = 1f,
        increasedGravity = 1f,
        decreasedGravity = 0.5f;
    public int jumpCount = 1, jumpCountMax = 1;

    public float jumpCooldown = 0.85f, timeSinceJump;
    public float rotateSmoothing = 0.1f;

    private LineRenderer laserSight;

    void Start()
    {
        cntrl = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        //Player movement.
             
        movement.z = Input.GetAxisRaw("Vertical") * currentSpeed;
        movement.x = Input.GetAxisRaw("Horizontal") * currentSpeed;

        //Jumping, dive, and jump cooldown.
        
        timeSinceJump += Time.deltaTime;
        
        if (cntrl.isGrounded)
        {
            transform.LookAt(transform.position + new Vector3(movement.x, 0, movement.z));
            
            
            jumpCount = 0;
        }
        else
        {
            movement.x = cntrl.velocity.x;
            movement.y -= gravity;
            movement.z = cntrl.velocity.z;
        }
        
        if (Input.GetButtonDown("Jump") && jumpCount < 1 && timeSinceJump > jumpCooldown && cntrl.isGrounded)
        {
            movement.y = jumpForce;
            jumpCount ++;
            timeSinceJump = 0;
        }
        else if (Input.GetButtonDown("Jump") && jumpCount < 2 && cntrl.isGrounded == false)
        {
            Vector3 diveDir = new Vector3(transform.forward.x, transform.forward.y + 0.5f, transform.forward.z);
            movement = diveDir * currentSpeed * 2f;
            transform.Rotate(90.0f,0f, 0f, relativeTo: Space.Self);
            jumpCount ++;
        }

        if (cntrl.velocity.y > 0)
        {
            gravity = decreasedGravity;
        }
        else if (cntrl.velocity.y < 0)
        {
            gravity = increasedGravity;
        }
        
        cntrl.Move(movement * Time.deltaTime);

        //Sprinting.

        if (Input.GetKey(KeyCode.LeftShift) && cntrl.isGrounded)
        {
            currentSpeed = speedySpeed;
        } 
        else
        {
            currentSpeed = defaultSpeed;
        }
    }
}
