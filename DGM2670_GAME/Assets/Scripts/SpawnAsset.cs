using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SpawnAsset : MonoBehaviour
{
    public Transform wallSpawn, bulletSpawn;
    public GameObject playerWall, playerBullet;
    private float bulletForce = 1000f;

    void Start()
    {
       
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootBullet();
        }
        
        if (Input.GetButtonDown("Fire2"))
        {
            BuildWall();
        }
     
    }

    void ShootBullet()
    {
        GameObject newBullet = Instantiate(playerBullet, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
        newBullet.AddComponent<Rigidbody>();
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce);
    }

    void BuildWall()
    {
        GameObject newWall = Instantiate(playerWall, wallSpawn.position, wallSpawn.rotation);
        Destroy(newWall, 3.0f);
    }
}
