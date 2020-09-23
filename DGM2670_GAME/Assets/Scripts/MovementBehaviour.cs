using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MovementBehaviour : MonoBehaviour
{
    public CharacterController control; 
    private Vector3 movement;
    public float gravity = 9.81f;
    public float moveSpeed = 3f;
    public float jumpForce = 10f;
    public int jumpCount = 1;
    
    void Start()
    {
        
    }


    void Update()
    {
        movement.z = Input.GetAxisRaw("Vertical")*moveSpeed;
        movement.x = Input.GetAxisRaw("Horizontal")*moveSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            movement.y = jumpForce;
        }

        if (control.isGrounded)
        {
            movement.y = 0;
        }
        else
        {
            movement.y -= gravity;
        }
        
        control.Move(movement * Time.deltaTime);
    }
}
