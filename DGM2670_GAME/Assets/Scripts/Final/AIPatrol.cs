using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrol : MonoBehaviour
{

    private NavMeshAgent agent;
    public List<GameObject> patrolPoints;
    private int i = 0;
   
    void Start()
    {
        i = 0;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (agent.pathPending || !(agent.remainingDistance < 0.5f)) return;
        agent.destination = patrolPoints[i].transform.position;
        i = (i + 1) % patrolPoints.Count;
    }
}
