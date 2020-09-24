using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddValueBehaviour : MonoBehaviour
{
    public IntData dataValue;
    
    void OnTriggerEnter(Collider col)
    {
        dataValue.value++;

        if (col.gameObject.name == "Player")
        {
            Destroy(this.gameObject); 
        }
    }
}
