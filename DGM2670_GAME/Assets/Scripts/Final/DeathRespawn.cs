using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeathRespawn : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPos;
    public GameObject newBlock;
    public GameObject newBlockPos;

    public AudioSource slimeSplat;

    private int randomInt;

    void Awake()
    {
        slimeSplat.volume = 0f;
        slimeSplat = GetComponent<AudioSource>();
        player = GameObject.Find("Humanoid_01").transform;
    }

    void Start()
    {
        StartCoroutine(SetVolume());
    }

    void OnTriggerEnter(Collider other)
    {
        slimeSplat.Play();
        if (other.gameObject.name == "Humanoid_01")
        {
            player.transform.position = respawnPos.transform.position;
            lifeCounterBehaviour.life = lifeCounterBehaviour.life - 1;
        }

        if (other.gameObject.tag == "Block")
        {
            StartCoroutine(SpawnBlock());
        }
    }
    
    IEnumerator SetVolume()
    {
        yield return new WaitForSeconds(2f);
        slimeSplat.volume = 1f;
    }

    IEnumerator SpawnBlock()
    {
        Instantiate(newBlock, newBlockPos.transform.position, newBlockPos.transform.rotation);
        yield return null;
    }
}
