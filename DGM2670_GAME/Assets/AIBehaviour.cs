using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.WSA.Input;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBehaviour : MonoBehaviour
{

    private NavMeshAgent agent;
    private Rigidbody agentRB;
    public GameObject playerLocation;
    public float chargeCooldown = 2f, timeSinceCharge;
    public bool targetInBounds = false;
    
    public List<GameObject> patrolPoints;
    private int i = 0;

    void Awake()
    {
        playerLocation = GameObject.FindWithTag("Player");
    }
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agentRB = GetComponent<Rigidbody>();
        i = 0;
    }

    void Update()
    {
        timeSinceCharge += Time.deltaTime;
        
        if (targetInBounds == false)
        {
            if (agent.pathPending || !(agent.remainingDistance < 0.5f))
            {
                agent.speed = 3.5f;
                return;
            }
            agent.destination = patrolPoints[i].transform.position;
            i = (i + 1) % patrolPoints.Count;
        }
        else
        {
            agent.destination = playerLocation.transform.position;
            agent.speed = 20;
            timeSinceCharge = 0;
        }
    }
    
  
    
    //Add patrol points so the crab won't charge again until he has reached the most recent point that was dropped. (Point drops ontriggerenter.)
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && timeSinceCharge > chargeCooldown)
        {
            //agent.destination = playerLocation.transform.position;
            //agent.speed = 25;
            //timeSinceCharge = 0;
            targetInBounds = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        targetInBounds = false;
    }
    
        
        
  
}
