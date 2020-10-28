using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Rolling Log")
        {
            Destroy(other.gameObject);
        }
    }
}
