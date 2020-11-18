using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRespawn : MonoBehaviour
{

    public GameObject respawnPos;
    public GameObject[] humanoids;
    public GameObject player;

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
