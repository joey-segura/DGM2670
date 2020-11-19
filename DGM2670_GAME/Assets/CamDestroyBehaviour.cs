using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamDestroyBehaviour : MonoBehaviour
{
    public Rigidbody piece;
    
    void Start()
    {
        piece = GetComponent<Rigidbody>();
    }
    
    void OnTriggerEnter()
    {
        if (GameObject.FindWithTag("Player"))
        {
            piece.isKinematic = false;
        }
    }
}
