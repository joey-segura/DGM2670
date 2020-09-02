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
    public float currentSpeed, defaultSpeed = 3f, speedySpeed = 6f, jumpForce = 20f, gravity = 1f;
    public int jumpCount = 1, jumpCountMax = 1;
    public bool stunned = false;

    void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    void Update()
    {
        movement.z = Input.GetAxisRaw("Vertical")*currentSpeed;
        movement.x = Input.GetAxisRaw("Horizontal")*currentSpeed;

        if (Input.GetButtonDown("Jump") && jumpCount < jumpCountMax)
        {
            movement.y = jumpForce;
            jumpCount ++;
        }

        if (cntrl.isGrounded)
        {
            movement.y = 0;
            jumpCount = 0;
        }
        else
        {
            movement.y -= gravity;
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
