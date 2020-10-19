using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_TubeSpawner : MonoBehaviour
{
    public Transform tubeLocation;
    public GameObject rollingLog;

    public int i;
    
    void Update()
    {
        if (Time.time> i)
        {
            i += 5;
            GameObject rollingLogClone = (GameObject)Instantiate(rollingLog, tubeLocation.position, tubeLocation.rotation);
            
            Destroy(rollingLogClone, 20f);
        }
    }
    
    
}
