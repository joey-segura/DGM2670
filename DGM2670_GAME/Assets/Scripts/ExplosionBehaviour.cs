using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ExplosionBehaviour: MonoBehaviour
{
    public GameObject bomb;
    public float power = 10f, radius = 5f, liftForce = 1f;

    void OnTriggerEnter(Collider col)
    {
        Vector3 explosionPosition = bomb.transform.position;
        Collider[] collider = Physics.OverlapSphere(explosionPosition, radius);
        
        foreach (Collider hit in collider) 
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            { 
                rb.AddExplosionForce(power, explosionPosition, radius, liftForce, ForceMode.Impulse);
            }
        }
        Destroy(this.gameObject);
    }
}

