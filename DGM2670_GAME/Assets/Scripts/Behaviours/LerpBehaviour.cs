using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class LerpBehaviour : MonoBehaviour
{

    public Transform startPos, endPos;

    public float travelDist = 5f;

    
    void Update()
    {
        {
            float distTravelled = Mathf.PingPong(Time.time, travelDist);
            transform.position = Vector3.Lerp(startPos.position, endPos.position, distTravelled / travelDist);
        }
    }
}
