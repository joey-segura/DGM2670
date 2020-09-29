using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveBehaviour : MonoBehaviour
{
    private Rigidbody playerRB;
    private Vector3 newPosition;

    public float lookSpeed = 10f;
    
    
    
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 newPosition = transform.position;
        
        if (Input.GetKey(KeyCode.W))
        {
            newPosition += (Vector3.forward * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.S))
        {
            newPosition += (Vector3.back * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            newPosition += (Vector3.right * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.A))
        {
            newPosition += (Vector3.left * Time.deltaTime);
        }
            
        playerRB.MovePosition(newPosition);
        transform.LookAt(transform.position + new Vector3(newPosition.x * lookSpeed, 0, newPosition.z * lookSpeed));
    }
}
