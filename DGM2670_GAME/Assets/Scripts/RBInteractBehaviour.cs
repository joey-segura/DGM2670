using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBInteractBehaviour : MonoBehaviour
{
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rbody = hit.collider.attachedRigidbody;
        if (rbody != null && !rbody.isKinematic)
        {
            rbody.velocity += hit.controller.velocity;
        }
    }
}
