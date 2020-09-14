using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SpawnWall : MonoBehaviour
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
        GameObject newBullet = Instantiate(playerBullet, bulletSpawn.position, bulletSpawn.rotation);
        playerBullet = newBullet;
        Rigidbody bulletRB = playerBullet.GetComponent<Rigidbody>();
        bulletRB.AddForce(transform.forward * bulletForce);
    }

    void BuildWall()
    {
        GameObject newWall = Instantiate(playerWall, wallSpawn.position, wallSpawn.rotation);
        Rigidbody wallRB = playerWall.GetComponent<Rigidbody>();
        Destroy(newWall, 3.0f);
    }
}
