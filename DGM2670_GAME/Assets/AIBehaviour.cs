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

    public bool canNavigate;
    
    private WaitForFixedUpdate wffu;
   
    public float holdTime = 1f;
    
    private WaitForSeconds wfs;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerLocation = GameObject.Find("Humanoid_01");
        wfs = new WaitForSeconds(holdTime);
    }
    
    //Add patrol points so the crab won't charge again until he has reached the most recent point that was dropped. (Point drops ontriggerenter.)
    
    private void OnTriggerEnter(Collider other)
    {
        agent.destination = playerLocation.transform.position;
        agent.speed = 2f;
    }
}
