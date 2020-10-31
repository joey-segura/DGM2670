using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRespawn : MonoBehaviour
{

    public GameObject respawnPos;
    public GameObject[] humanoids;
    public GameObject player;

    private int randomInt;
    
    public AT_PlayerMoveBehaviour playerMoveScript;
    
    void Update()
    {
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
        player.transform.position = respawnPos.transform.position;
        player.SetActive(false);
        playerMoveScript.canMove = true;
        playerMoveScript.currentSpeed = 0f;
        
        SpawnNewHumanoid();
    }

    void SpawnNewHumanoid()
    {
        randomInt = Random.Range(0, humanoids.Length);
        Instantiate(humanoids[randomInt], player.transform.position, player.transform.rotation);
    }
}
