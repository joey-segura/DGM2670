using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_PlatformInteract : MonoBehaviour
{
    public GameObject player;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = transform;
            Debug.Log("Triggering");
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}

