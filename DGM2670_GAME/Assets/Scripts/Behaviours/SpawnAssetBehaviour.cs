﻿using UnityEngine;

public class SpawnAssetBehaviour : MonoBehaviour
{
//    public Transform wallSpawn, bulletSpawn;
//    public GameObject playerWall, playerBullet;
//    private float bulletForce = 2000f;
//
//    void Start()
//    {
//        
//    }
//    
//    void Update()
//    {
//        if (Input.GetButtonDown("Fire1"))
//        {
//            ShootBullet();
//        }
//        
//        if (Input.GetButtonDown("Fire2"))
//        {
//            BuildWall();
//        }
//    }
//
//    void ShootBullet()
//    {
//        GameObject newBullet = Instantiate(playerBullet, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
//        newBullet.AddComponent<Rigidbody>();
//        newBullet.AddComponent<LineRenderer>();
//        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce);
//    }
//
//    void BuildWall()
//    {
//        GameObject newWall = Instantiate(playerWall, wallSpawn.position, wallSpawn.rotation);
//        Destroy(newWall, 3.0f);
//    }
}
