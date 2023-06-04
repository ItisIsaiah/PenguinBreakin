using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PenguinBase : MonoBehaviour
{
     public PenguinScriptableObject penType;
    [SerializeField] Transform[] path;//The path that the penguin will walk on
    [SerializeField] Transform[] scaredPoints;//The penguin will run to these if they are scared
    public NavMeshAgent agent;
    public FOV sight;
    public GameObject playerRef;
    public float health = 10f;
    public int point;
    [Range(0f, 5f)]
    public float distanceFromPoint;

    bool isDoingAction = false;
    bool isWalkingToPoint;
    public Transform hitpoint;
    float hitRadius;
    LayerMask playerMask;

    public bool penLock = false;
    virtual public void Start()
    {
        isDoingAction = false;
        isWalkingToPoint = false;
        health = penType.health;
        playerRef = GameObject.FindGameObjectWithTag("Player");
        //agent = GetComponent<NavMeshAgent>();
        sight = GetComponent<FOV>();
        point = 0;
    }
    private void Update()
    {
        
        if (sight.canSee && Vector3.Distance(transform.position,playerRef.transform.position)>.5f&&!penType.scared&&!isDoingAction) {
           
                agent.SetDestination(playerRef.transform.position);
            isDoingAction = true;
         }
        else if (sight.canSee && Vector3.Distance(transform.position, playerRef.transform.position) > .5f && penType.scared&&!isDoingAction)
        {
            int randomPoint=Random.Range(0,scaredPoints.Length-2);
            if (randomPoint < scaredPoints.Length - 2) { agent.SetDestination(scaredPoints[randomPoint].position); }
            isDoingAction = true;

        }
        if (sight.canSee && Vector3.Distance(transform.position, playerRef.transform.position) > .2f && penType.aggressive&&!isDoingAction)
        {
            
            StartCoroutine(hit());
            int randomPoint = Random.Range(0, scaredPoints.Length - 2);
            if (randomPoint < scaredPoints.Length - 2) { agent.SetDestination(scaredPoints[randomPoint].position); }
            isDoingAction = true;

        }
        else if (sight.canSee && Vector3.Distance(transform.position, playerRef.transform.position) > .2f && !penType.aggressive&&!isDoingAction)
        {
            //run
        }

       

        if (health == 0)
        {
            Destroy(this.gameObject);
        }

        #region path code

        if (!sight.canSee)
        {
            if ( Vector3.Distance(transform.position, path[point].position) > distanceFromPoint && !isWalkingToPoint)
            {
                agent.SetDestination(path[point].position);
                isWalkingToPoint = true;
            }
            
            else if (Vector3.Distance(transform.position, path[point].position) < distanceFromPoint  ) {
                if (!(point >= path.Length-1))
                {
                    point++;
                }
                else
                {
                    point = 0;
                }
                isWalkingToPoint = false;
            }
        }
        #endregion
        
    }
    
     IEnumerator hit()
    {
       // StartCoroutine(DoRotationAtTargetDirection(playerRef.transform));
        Collider[] hitboxes = Physics.OverlapSphere(hitpoint.position, hitRadius, playerMask);

        foreach (Collider playerC in hitboxes)
        {//Swing Animation
            if (playerC.CompareTag("Player"))
            {
                PlayerMove playerScript = playerRef.GetComponent<PlayerMove>();
                yield return new WaitForSeconds(.2f);
                playerScript.takeHit(penType.damage);
               
            }
        }
    }

    IEnumerator DoRotationAtTargetDirection(Transform opponentPlayer)
    {
        Quaternion targetRotation = Quaternion.identity;
        do
        {
            Debug.Log("do rotation");
            Vector3 targetDirection = opponentPlayer.position - transform.position;
            targetRotation = Quaternion.LookRotation(targetDirection);
            Quaternion nextRotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);
            transform.rotation = nextRotation;
            yield return null;

        } while (Quaternion.Angle(transform.localRotation, targetRotation) < 0.01f);

        
    }
    public virtual IEnumerator gotHit()
    {
        yield return new WaitUntil(()=>penLock==true);
       // Debug.Log("I got hit");
        health--;
        penLock = false;
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
