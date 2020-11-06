using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigAnimControl : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 movement;

    public Animator anim;
    public float jumpForce = 1000f;
    public float speed = 1f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        rb.velocity = new Vector3();

        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed * Time.deltaTime;
        
        rb.MovePosition(transform.position + movement);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
             anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);
            rb.AddForce(Vector3.up * jumpForce);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
    }
}
