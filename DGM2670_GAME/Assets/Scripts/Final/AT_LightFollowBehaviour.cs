using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_LightFollowBehaviour : MonoBehaviour
{
    public GameObject lightFocus;
    public float followSpeed = 0.1f;
    public float lerpSpeed = 0.5f;
    public bool lightFollowActive = false;

    void LateUpdate()
    {
        lightFocus = GameObject.FindWithTag("Player");
        if (transform.position != lightFocus.transform.position && lightFollowActive == true)
        {
            Vector3 playerPosition = new Vector3(lightFocus.transform.position.x + 8f, lightFocus.transform.position.y - 16f, lightFocus.transform.position.z - 11f);
            transform.position = Vector3.Lerp(transform.position, playerPosition, followSpeed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            lightFollowActive = true;
        }
    }
}
