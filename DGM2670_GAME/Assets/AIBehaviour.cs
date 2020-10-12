using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.WSA.Input;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBehaviour : MonoBehaviour
{

    private NavMeshAgent agent;
    public GameObject playerLocation;
    public float chargeCooldown = 2f, timeSinceCharge;
    public bool isCharging;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerLocation = GameObject.Find("Humanoid_01");
        isCharging = false;
    }

    void Update()
    {
        timeSinceCharge += Time.deltaTime;
    }
    
    //Add patrol points so the crab won't charge again until he has reached the most recent point that was dropped. (Point drops ontriggerenter.)
    
    private void OnTriggerStay(Collider other)
    {
        if (timeSinceCharge > chargeCooldown)
        {
            agent.destination = playerLocation.transform.position;
            agent.speed = 25;
            timeSinceCharge = 0;
        }
    }
}
