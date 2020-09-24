using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckBehaviour : MonoBehaviour
{
    public bool IsGrounded;
    
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ground")
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }
}
