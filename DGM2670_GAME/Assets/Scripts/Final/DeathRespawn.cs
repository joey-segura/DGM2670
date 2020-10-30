using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRespawn : MonoBehaviour
{

    public Vector3 respawnPos;
    public GameObject player;

    public AT_PlayerMoveBehaviour playerMoveScript;

    void Start()
    {
        respawnPos = new Vector3(100f,109f,-14.1f);
        player = GameObject.FindWithTag("Player");
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        playerMoveScript.canMove = false;
        yield return new WaitForSeconds(3f);
        player.transform.position = respawnPos;
        playerMoveScript.canMove = true;
        playerMoveScript.currentSpeed = 0f;
    }
}
