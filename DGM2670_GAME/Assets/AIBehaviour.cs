using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.WSA.Input;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBehaviour : MonoBehaviour
{

    private NavMeshAgent agent;

    public Transform player;

    public bool canNavigate;
    
    private WaitForFixedUpdate wffu;
   
    public float holdTime = 1f;
    
    private WaitForSeconds wfs;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wfs = new WaitForSeconds(holdTime);
    }
    
    private IEnumerator Navigate()
    {
        canNavigate = true;

        while (canNavigate)
        {
            yield return wffu;
            agent.destination = player.position;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        canNavigate = false;
        StartCoroutine(Navigate());
    }
    private void OnTriggerExit(Collider other)
    {
        canNavigate = false;
        agent.destination = this.transform.position;
    }
}
