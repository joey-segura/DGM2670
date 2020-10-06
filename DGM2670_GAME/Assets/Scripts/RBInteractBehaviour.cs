using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBInteractBehaviour : MonoBehaviour
{
    private float pushStrength = 2f;
    private float rotateStrength = 1f;

    //Make the mass affect the push strength.
    private float objectMass;
    
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
        
        rbody.velocity = pushDirection * pushStrength;
        
        //float axis = Input.GetAxis("Horizontal");
        //rbody.AddTorque(rbody.transform.up.normalized * rotateStrength * axis, ForceMode.Impulse);
    }
}
