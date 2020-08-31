using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWall : ThirdPersonMove
{
    public Transform spawnPoint;
    public GameObject playerWall;


 
    
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            BuildWall();
        }
    }

    void BuildWall()
    {
        GameObject newWall =Instantiate(playerWall, spawnPoint.position, spawnPoint.rotation);
        //Quaternion.Euler(new Vector3(0,0,0))
        Rigidbody rb = newWall.GetComponent<Rigidbody>();
        Destroy(newWall, 3.0f);
    }
}
