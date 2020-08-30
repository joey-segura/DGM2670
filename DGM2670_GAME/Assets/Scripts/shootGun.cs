using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class shootGun : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject playerWall;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            SpawnWall();
        }
    }

    void SpawnWall()
    {
        GameObject newWall =Instantiate(playerWall, spawnPoint.position, spawnPoint.rotation);
        Rigidbody rb = newWall.GetComponent<Rigidbody>();
        Destroy(newWall, 3.0f);
    }
}
