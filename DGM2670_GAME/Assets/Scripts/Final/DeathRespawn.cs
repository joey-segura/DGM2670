using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeathRespawn : MonoBehaviour
{

    public GameObject respawnPos;
    public GameObject[] humanoids;
    public GameObject player;
    public GameObject newBlock;
    public GameObject newBlockPos;


    public AudioSource slimeSplat;

    private int randomInt;

    void Awake()
    {
        slimeSplat.volume = 0f;
        slimeSplat = GetComponent<AudioSource>();
    }

    void Start()
    {
        StartCoroutine(SetVolume());
    }

    IEnumerator SetVolume()
    {
        yield return new WaitForSeconds(2f);
        slimeSplat.volume = 1f;
    }
    
    void Update()
    {
        player = GameObject.FindWithTag("Player");
    }
    
    void OnTriggerEnter(Collider other)
    {
        slimeSplat.Play();
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Respawn());
            lifeCounterBehaviour.life = lifeCounterBehaviour.life - 1;
        }

        if (other.gameObject.tag == "Block")
        {
            StartCoroutine(SpawnBlock());
        }
    }

    IEnumerator Respawn()
    {
        player.transform.position = respawnPos.transform.position;
        player.SetActive(false);

        SpawnNewHumanoid();
        yield return null;
    }

    IEnumerator SpawnBlock()
    {
        Debug.Log("Block hit");
        Instantiate(newBlock, newBlockPos.transform.position, newBlockPos.transform.rotation);
        yield return null;
    }

    void SpawnNewHumanoid()
    {
        randomInt = Random.Range(0, humanoids.Length);
        Instantiate(humanoids[randomInt], player.transform.position, player.transform.rotation);
    }
}
