using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class deathByCrab : MonoBehaviour
{
    public GameObject respawnPos;
    public GameObject[] humanoids;
    public GameObject player;

    public AudioSource chomp;

    private int randomInt;
    
    public AT_PlayerMoveBehaviour playerMoveScript;

    void Awake()
    {
        chomp.volume = 0f;
        chomp = GetComponent<AudioSource>();
    }

    void Start()
    {
        StartCoroutine(SetVolume());
    }

    IEnumerator SetVolume()
    {
        yield return new WaitForSeconds(2f);
        chomp.volume = 0.5f;
    }
    
    void Update()
    {
        player = GameObject.FindWithTag("Player");
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            chomp.Play();
            StartCoroutine(Respawn());
            lifeCounterBehaviour.life = lifeCounterBehaviour.life - 1;
        }
    }

    IEnumerator Respawn()
    {
        player.transform.position = respawnPos.transform.position;
        player.SetActive(false);

        SpawnNewHumanoid();
        yield return null;
    }

    void SpawnNewHumanoid()
    {
        randomInt = Random.Range(0, humanoids.Length);
        Instantiate(humanoids[randomInt], player.transform.position, player.transform.rotation);
    }
}