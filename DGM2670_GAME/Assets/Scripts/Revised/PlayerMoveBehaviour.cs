using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveBehaviour : MonoBehaviour
{
    private Rigidbody playerRB;
    private Vector3 newPosition;

    public float moveSpeed = 5f;
    public float lookSpeed = 100f;
    
    
    
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 newPosition = transform.position;
        
        if (Input.GetKey(KeyCode.W))
        {
            newPosition += (Vector3.forward * moveSpeed * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.S))
        {
            newPosition += (Vector3.back * moveSpeed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            newPosition += (Vector3.right * moveSpeed * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.A))
        {
            newPosition += (Vector3.left * moveSpeed * Time.deltaTime);
        }
            
        playerRB.MovePosition(newPosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
    }
}
