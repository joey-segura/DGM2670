using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class VanishOnCollision : MonoBehaviour
{
    public Animator scaleAnimator;
    public Renderer meshRend;
    public Collider vanishCol;

    void Start()
    {
        scaleAnimator = gameObject.GetComponent<Animator>();
        meshRend = gameObject.GetComponent<Renderer>();
        vanishCol = gameObject.GetComponent<MeshCollider>();
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            
            scaleAnimator.SetBool("Shrink", true);
            StartCoroutine("Vanish");
        }
    }
    
    IEnumerator Vanish()
    {
        yield return new WaitForSeconds(1.4f);

        meshRend.enabled = false;
        vanishCol.enabled = false;
        
        yield return new WaitForSeconds(3);
        
        scaleAnimator.SetBool("Shrink", false);
        
        meshRend.enabled = true;
        vanishCol.enabled = true;
    }
}
