using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBInteractBehaviour : MonoBehaviour
{
    public float pushStrength = 20f;

    public AT_PlayerMoveBehaviour playerMoveBehaviour;

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

        Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        
        //rbody.velocity = pushDirection * playerMoveBehaviour.currentSpeed * 0.5f * pushStrength;
        rbody.AddForce(pushDirection * pushStrength);
    }
    
    
}
