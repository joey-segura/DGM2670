﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class deathByCrab : MonoBehaviour
{
    public GameObject respawnPos;
    public GameObject[] humanoids;
    public GameObject player;

    public AudioSource slimeSplat;

    private int randomInt;
    
    public AT_PlayerMoveBehaviour playerMoveScript;

    void Awake()
    {
        //slimeSplat.volume = 0f;
        //slimeSplat = GetComponent<AudioSource>();
    }

    void Start()
    {
        //StartCoroutine(SetVolume());
    }

    //IEnumerator SetVolume()
    //{
        //yield return new WaitForSeconds(2f);
        //slimeSplat.volume = 1f;
    //}
    
    void Update()
    {
        player = GameObject.FindWithTag("Player");
    }
    
    void OnTriggerEnter(Collider other)
    {
        //slimeSplat.Play();
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Triggered");
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        player.transform.position = respawnPos.transform.position;
        player.SetActive(false);
        playerMoveScript.canMove = true;
        playerMoveScript.currentSpeed = 0f;
        
        SpawnNewHumanoid();
        yield return null;
    }

    void SpawnNewHumanoid()
    {
        randomInt = Random.Range(0, humanoids.Length);
        Instantiate(humanoids[randomInt], player.transform.position, player.transform.rotation);
    }
}