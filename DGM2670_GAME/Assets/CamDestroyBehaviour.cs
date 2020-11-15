using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamDestroyBehaviour : MonoBehaviour
{

    public GameObject secCam;

    void OnTriggerEnter()
    {
        Debug.Log("Triggered");
        Invoke("DetachChildren", 0);
    }

    public void DetachChildren(GameObject obj, bool isKin)
    {
        Rigidbody[] rBodies = gameObject.GetComponentsInChildren<Rigidbody>();
        
        for (int i=0; i < rBodies.Length; i++)
        {
            rBodies[i].isKinematic = true;
        }
    }
}
