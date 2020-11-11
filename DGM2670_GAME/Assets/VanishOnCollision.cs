using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class VanishOnCollision : MonoBehaviour
{
    public float newScale = 0.1f;
    public float startScale;
    public float shrinkSpeed = 10f;

    public bool shrink;

    void Start()
    {
        shrink = false;
    }
    
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Hit");
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine("Vanish");
            shrink = true;
        }
    }

    void Update()
    {
        Debug.Log(this.gameObject.transform.localScale);

        if (shrink == true)
        {
            newScale = Mathf.MoveTowards(newScale, startScale, Time.deltaTime * shrinkSpeed);
            gameObject.transform.localScale = new Vector3(newScale, newScale, newScale);
            
            //this.gameObject.transform.localScale -= Vector3.one * Time.deltaTime * shrinkSpeed;
        }
    }
    
    IEnumerator Vanish()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
