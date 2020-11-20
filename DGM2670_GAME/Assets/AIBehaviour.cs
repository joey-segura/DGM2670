using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.WSA.Input;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class AIBehaviour : MonoBehaviour
{

    private NavMeshAgent agent;
    private Rigidbody agentRB;
    public GameObject playerLocation;
    public float chargeCooldown = 2f, timeSinceCharge;
    
    public List<GameObject> patrolPoints;
    private int i = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agentRB = GetComponent<Rigidbody>();
        i = 0;
    }
    
    void Update()
    {
        playerLocation = GameObject.FindWithTag("Player");
        timeSinceCharge += Time.deltaTime;

        if (Vector3.Distance(this.gameObject.transform.position, playerLocation.transform.position) < 12)
        {
            agent.destination = playerLocation.transform.position + (playerLocation.transform.position - this.gameObject.transform.position).normalized * 10f;
            agent.speed = 20f;
        }
        else
        {
            agent.speed = 3.5f;
            if (agent.pathPending || !(agent.remainingDistance < 0.5f)) return;
            agent.destination = patrolPoints[i].transform.position;
            i = (i + 1) % patrolPoints.Count;
        }
    }
}
