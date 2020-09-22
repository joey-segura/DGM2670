using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookBehaviour : MonoBehaviour
{
    public Transform pointObj;

    void Update()
    {
        transform.LookAt(pointObj);
    }
}    
    
    


