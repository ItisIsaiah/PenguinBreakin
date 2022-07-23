using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PenguinBase : MonoBehaviour
{
    public NavMeshAgent agent;
    public FOV sight;
    public GameObject playerRef;
    public void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        sight = GetComponent<FOV>();
    }
    private void Update()
    {
        if (sight.canSee && Vector3.Distance(transform.position,playerRef.transform.position)>.5f) {
            agent.SetDestination(playerRef.transform.position);
       }
    }
}
