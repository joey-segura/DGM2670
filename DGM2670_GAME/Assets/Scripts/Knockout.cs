using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Knockout : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            FindObjectOfType<gameManager>().Respawn();
            Destroy(this.gameObject); 
        }
    }
}
