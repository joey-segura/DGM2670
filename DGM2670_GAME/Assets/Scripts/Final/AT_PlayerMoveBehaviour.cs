﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class AT_PlayerMoveBehaviour : MonoBehaviour

{
    public CharacterController cntrl;
    public Camera cam;

    private Vector3 movement;
    public float rayLength;
   
    
    public float currentSpeed,
        defaultSpeed = 4f,
        speedySpeed = 6f,
        jumpForce = 11f,
        gravity = 1f,
        increasedGravity = 1f,
        decreasedGravity = 0.5f;
    public int jumpCount = 1, jumpCountMax = 1;

    public float jumpCooldown = 0.85f, timeSinceJump;

    private LineRenderer laserSight;

    void Start()
    {
        cntrl = GetComponent<CharacterController>();
        cam = FindObjectOfType<Camera>();
    }
    
    void Update()
    {
        //Player movement.
             
        movement.z = Input.GetAxisRaw("Vertical")*currentSpeed;
        movement.x = Input.GetAxisRaw("Horizontal")*currentSpeed;

        //Jumping and jump cooldown.
        
        timeSinceJump += Time.deltaTime;
        
        
        if (cntrl.isGrounded)
        {
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
            Vector3 diveDir = new Vector3(transform.forward.x, transform.forward.y, transform.forward.z);
            movement = diveDir * currentSpeed * 2f;
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
        
        transform.LookAt(transform.position + new Vector3(movement.x, 0, movement.z));
        
        
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
