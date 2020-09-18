using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public Vector3 playerLocation;
    private LineRenderer laser;
    
    void Start()
    {
        playerLocation = GameObject.Find("Player").transform.position;
        laser = GetComponent<LineRenderer>();
    }
    
    void Update()
    {
        Vector3 origin = this.gameObject.transform.position;
        Vector3 direction = transform.forward;
        
        Debug.DrawRay(origin, direction * 10f, Color.red);

        RaycastHit hit;
        Ray gunRay = new Ray(origin, direction);
        laser.SetPosition(0, origin);

        if (Physics.Raycast(gunRay, out hit))
        {
            hit.point = playerLocation;
            Debug.Log(hit.point);
            laser.SetPosition(1, hit.point);
        }
        
        transform.LookAt(hit.point);
    }
}
