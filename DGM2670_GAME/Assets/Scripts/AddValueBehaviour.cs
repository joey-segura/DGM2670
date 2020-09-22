using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddValueBehaviour : MonoBehaviour
{
    public IntData ammoValue;
    
    void OnTriggerEnter(Collider col)
    {
        ammoValue.value++;

        if (col.gameObject.name == "Player")
        {
            Destroy(this.gameObject); 
        }
    }
}
