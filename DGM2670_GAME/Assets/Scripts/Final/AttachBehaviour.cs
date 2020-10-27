using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachBehaviour : MonoBehaviour
{
  
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Moving Platform")
        {
            transform.parent = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        transform.parent = null;
    }
}
