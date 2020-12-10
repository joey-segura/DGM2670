using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamDestroyBehaviour : MonoBehaviour
{
    public Rigidbody piece;
    
    public AudioSource zap;
    
    void Awake()
    {
        zap.volume = 0f;
        zap = GetComponent<AudioSource>();
    }
    
    void Start()
    {
        StartCoroutine(SetVolume());
        piece = GetComponent<Rigidbody>();
    }
    
    IEnumerator SetVolume()
    {
        yield return new WaitForSeconds(2f);
        zap.volume = 0.5f;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            zap.Play();
            piece.isKinematic = false;
        }
    }
}
