using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonMove : MonoBehaviour
{
    public CharacterController cntrl;
    public Camera cam;
    
    private Vector3 movement;
    public float rayLength;

    public float currentSpeed,
        defaultSpeed = 3f,
        speedySpeed = 6f,
        jumpForce = 10f,
        gravity = 1f,
        increasedGravity = 1f,
        decreasedGravity = 0.5f;
    public int jumpCount = 1, jumpCountMax = 1;
    public bool stunned, jumpCD;

    public float jumpCooldown = 0.75f, timeSinceJump;

    void Start()
    {
        cntrl = GetComponent<CharacterController>();
        cam = FindObjectOfType<Camera>();
        stunned = false;
    }

    void Update()
    {
        movement.z = Input.GetAxisRaw("Vertical")*currentSpeed;
        movement.x = Input.GetAxisRaw("Horizontal")*currentSpeed;
        
        timeSinceJump += Time.deltaTime;
        
        if (Input.GetButtonDown("Fire1") && jumpCount < jumpCountMax && timeSinceJump > jumpCooldown && cntrl.isGrounded)
        {
            movement.y = jumpForce;
            jumpCount ++;
            timeSinceJump = 0;
        }

        if (cntrl.isGrounded)
        {
            jumpCount = 0;
        }
        else
        {
            movement.y -= gravity;
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
        
        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 focusPoint = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, focusPoint, Color.red);
            transform.LookAt(focusPoint);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = speedySpeed;
            Debug.Log("Sprinting");
        } 
        else
        {
            currentSpeed = defaultSpeed;
        }
    }
}
