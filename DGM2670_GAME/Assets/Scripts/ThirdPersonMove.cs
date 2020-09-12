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

    public Health healthBar;
    public int maxHP = 100, currentHP;

    public float currentSpeed,
        defaultSpeed = 4f,
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

        currentHP = maxHP;
        healthBar.SetHealth(maxHP);
        
        stunned = false;
    }

    //Trigger damage.

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "HP_Down")
        {
            TakeDamage(20);
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "HP_Up")
        {
            TakeDamage(-20);
            Destroy(other.gameObject);
        }
    }
    
    //Deal Damage.

    void TakeDamage(int damage)
    {
        currentHP -= damage;
        healthBar.SetHealth(currentHP);
    }

    void Update()
    {
        //Player death.
        
        if (currentHP <= 0)
        {
            FindObjectOfType<gameManager>().Respawn();
        }
        
        movement.z = Input.GetAxisRaw("Vertical")*currentSpeed;
        movement.x = Input.GetAxisRaw("Horizontal")*currentSpeed;
        
        //Jumping and jump cooldown.
        
        timeSinceJump += Time.deltaTime;
        
        if (Input.GetButtonDown("Jump") && jumpCount < jumpCountMax && timeSinceJump > jumpCooldown && cntrl.isGrounded)
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
        
        //Look at mouse position.
        
        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 focusPoint = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, focusPoint, Color.red);
            transform.LookAt(focusPoint);
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

        if (movement.y < -20f)
        {
            FindObjectOfType<gameManager>().Respawn();
        }
    }
}
