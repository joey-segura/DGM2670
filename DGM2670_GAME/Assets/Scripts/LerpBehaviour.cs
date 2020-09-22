using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class LerpBehaviour : MonoBehaviour
{
    public Vector3 vOne, vTwo;
    public float newLocation;
    
    void Update()
    {
        var direction = Vector3.Lerp(vOne, vTwo, newLocation);
        newLocation += 0.1f * Time.deltaTime;
        transform.Translate(direction);
    }
}
