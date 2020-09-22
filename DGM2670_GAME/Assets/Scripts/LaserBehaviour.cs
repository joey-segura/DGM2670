using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{

    public Vector3 playerLocation;
    public bool playerVisible;
    private LineRenderer laser;
    
    
    void Start()
    {
        laser = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            playerVisible = false;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            playerVisible = true;
        }
        
        
        
        playerLocation = GameObject.Find("Player").transform.position;
        Debug.Log(playerLocation);

        if (playerVisible == true)
        {
            transform.LookAt(playerLocation);
        }
        

        RaycastHit hit;
        Ray gunRay = new Ray(transform.position, transform.forward);
        laser.SetPosition(0, transform.position);

        if (Physics.Raycast(gunRay, out hit))
        {
            laser.SetPosition(1, hit.point);
        }
    }
}
