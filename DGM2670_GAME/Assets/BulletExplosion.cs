using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    public GameObject explosionLocation;
    public float power = 10f, radius = 5f, liftForce = 1f;
    
    void OnTriggerEnter(Collider col)
    {
        Vector3 explosionPosition = explosionLocation.transform.position;
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
