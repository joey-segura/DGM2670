using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rolling Log")
        {
            Debug.Log("Destroyed");
            Destroy(other.gameObject);
        }
    }
}
