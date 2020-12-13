using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class deathByCrab : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPos;

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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Humanoid_01")
        {
            chomp.Play();
            player.transform.position = respawnPos.transform.position;
            lifeCounterBehaviour.life = lifeCounterBehaviour.life - 1;
        }
    }
}