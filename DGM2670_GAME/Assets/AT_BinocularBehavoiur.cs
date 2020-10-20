using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_BinocularBehavoiur : MonoBehaviour
{
    public AT_CameraBehaviour cameraBehaviour;

    void Awake()
    {
        cameraBehaviour = GameObject.Find("Main Camera").GetComponent<AT_CameraBehaviour>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        cameraBehaviour.fovMIN = 100.0f;
    }
    
    void OnTriggerExit(Collider other)
    {
        cameraBehaviour.fovMIN = 50.0f;
    }
}
