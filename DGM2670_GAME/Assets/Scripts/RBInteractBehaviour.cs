using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBInteractBehaviour : MonoBehaviour
{
    private float pushStrength = 2f;
    private float rotateStrength = 1f;

    public float refSpeed;

    public AT_PlayerMoveBehaviour playerMoveBehaviour = null;

    void Awake()
    {
        playerMoveBehaviour = GameObject.FindWithTag("Player").GetComponent<AT_PlayerMoveBehaviour>();
    }
    
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rbody = hit.collider.attachedRigidbody;
        
        if (rbody == null || rbody.isKinematic)
        {
            return;
        }
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        Vector3 pushDirection = new Vector3(hit.moveDirection.x, hit.moveDirection.y, hit.moveDirection.z);
        
        rbody.velocity = pushDirection * playerMoveBehaviour.currentSpeed * 0.5f;
    }
}
