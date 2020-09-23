using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(CharacterController))]
public class MoveBehaviour : MonoBehaviour
{
    public CharacterController cntrl;
    public Camera cam;
    private GameObject playerGun;
    public GameObject locator;

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
    

    void Start()
    {
        cntrl = GetComponent<CharacterController>();
        cam = FindObjectOfType<Camera>();
    }
    
    void Update()
    {

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
        
        if (movement.y < 3)
        {
            FindObjectOfType<GameManager>().Respawn();
        }
    }
}
