using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PenguinBase : MonoBehaviour
{
    [SerializeField] PenguinScriptableObject penType;
    [SerializeField] Transform[] path;
    public NavMeshAgent agent;
    public FOV sight;
    public GameObject playerRef;
    public int health = 1;
    public int point;
    [Range(0f, 5f)]
    public float distanceFromPoint;
    public void Start()
    {
        health = penType.health;
        playerRef = GameObject.FindGameObjectWithTag("Player");
        //agent = GetComponent<NavMeshAgent>();
        sight = GetComponent<FOV>();
        point = 0;
    }
    private void Update()
    {
        if (sight.canSee && Vector3.Distance(transform.position,playerRef.transform.position)>.5f) {
            agent.SetDestination(playerRef.transform.position);
       }
        if (health == 0)
        {
            Destroy(this.gameObject);
        }

        #region path code

        if (!sight.canSee)
        {
            if ( Vector3.Distance(transform.position, path[point].position) > distanceFromPoint)
            {
                agent.SetDestination(path[point-1].position);
               
            }
            
            else if (Vector3.Distance(transform.position, path[point].position) < distanceFromPoint) {
                if (path[point + 1])
                {
                    point++;
                }
                else
                {
                    point = 0;
                }
            }
        }
        #endregion
    }

    public void gotHit()
    {
        Debug.Log("I got hit");
        health--;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        #region path drawing
        for (int i = 0; i < path.Length; i++)
        {
            if (i < path.Length - 1)
            {
                Gizmos.DrawLine(path[i].position, path[i+1].position);
            }
            else
            {
                Gizmos.DrawLine(path[i].position, path[0].position);
            }
        }
        #endregion
    }
}
