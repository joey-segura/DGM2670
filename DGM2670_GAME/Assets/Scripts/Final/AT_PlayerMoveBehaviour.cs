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
        speedySpeed = 8f,
        jumpForce = 11f,
        gravity = 1f,
        increasedGravity = 1f,
        decreasedGravity = 0.5f;
    public int jumpCount = 1, jumpCountMax = 1;
    public float jumpCooldown = 0.85f, timeSinceJump;
    public float remainingSprint, sprintMax = 10f, sprintMin = 1f;
    
    private LineRenderer laserSight;

    void Start()
    {
        cntrl = GetComponent<CharacterController>();
        remainingSprint = sprintMax;
    }
    
    void Update()
    {
        Debug.Log(transform.parent);
        //Player movement.
        
        movement.z = Input.GetAxis("Vertical") * currentSpeed;
        movement.x = Input.GetAxis("Horizontal") * currentSpeed;

        //Jumping, dive, and jump cooldown.
        
        timeSinceJump += Time.deltaTime;
        
        if (cntrl.isGrounded)
        {
            transform.LookAt(transform.position + new Vector3(movement.x, 0, movement.z));
            jumpCount = 0;
        }
        else
        {
            currentSpeed = defaultSpeed;
            
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
        
        if (Input.GetKey(KeyCode.LeftShift) && remainingSprint > sprintMin && cntrl.isGrounded)
        {
            currentSpeed = speedySpeed;
            remainingSprint -= 0.1f;
        } 
        else
        {
            currentSpeed = defaultSpeed;
            remainingSprint += 0.1f;
        }
        
        
        //FOR TESTING PURPOSES ONLY
        if (Input.GetKeyDown(KeyCode.T) && cntrl.isGrounded)
        {
            movement.y = jumpForce * 2f;
        }
    }
}
