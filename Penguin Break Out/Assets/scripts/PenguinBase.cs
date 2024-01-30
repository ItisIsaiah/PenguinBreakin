using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PenguinBase : MonoBehaviour
{
     public PenguinScriptableObject penType;
    [SerializeField] Transform[] path;//The path that the penguin will walk on
   // [SerializeField] Transform[] scaredPoints;//The penguin will run to these if they are scared
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
    public float hitRadius=15.5f;
    LayerMask playerMask;

    public bool penLock = false;
    string myName="Pen?";


    float distanceFromPlayer;
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
    public virtual void Update()
    {
        distanceFromPlayer = Vector3.Distance(transform.position, playerRef.transform.position);
        //Debug.Log(penType.scared + " | "+penType.myName+ " | see: " + sight.canSee + "| Action: "+isDoingAction);
       
        //If you can see the player, arent scared and arent already doing somehting
        if (sight.canSee && distanceFromPlayer>.5f&&!penType.scared&&!isDoingAction) {
            if (penType.aggressive)
            {
                //if you are aggressive move towards the player until you are too far then hit them!
                if (distanceFromPlayer > 1.2)
                {
                    //Debug.Log("Tracking| Distance: "+distanceFromPlayer);

                    agent.SetDestination(playerRef.transform.position);
                    
                }
                else
                {
                    Debug.Log("Doing the thing");
                    StartCoroutine(hit());
                    running();
                    isDoingAction = true;
                }
            }
            else
            {
                //Just walk up to the player happily
                agent.SetDestination(playerRef.transform.position);
                isDoingAction = true;
            }
         }
        else if (sight.canSee && distanceFromPlayer > 2f && penType.scared&&!isDoingAction)
        {
            running();

        }







        #region path code
        //If you aren't doing anything and also cant see the player... Follow the path that you are given
        if (path.Length!=0)
        {
            if (!sight.canSee && !isDoingAction)
            {
                if (Vector3.Distance(transform.position, path[point].position) > distanceFromPoint && !isWalkingToPoint)
                {
                    agent.SetDestination(path[point].position);
                    isWalkingToPoint = true;
                }

                else if (Vector3.Distance(transform.position, path[point].position) < distanceFromPoint)
                {
                    if (!(point >= path.Length - 1))
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
        }
      
        #endregion
        
    }
    

    void running()
    {
        float runTImer = 0f;

        while (runTImer<=5f) {
            Vector3 dirToPlayer = transform.position - playerRef.transform.position;
            Vector3 newPos = transform.position + dirToPlayer*20;
            agent.SetDestination(newPos);
            runTImer += Time.deltaTime;
        }
        isDoingAction = false;
    }
     IEnumerator hit()
    {
        Debug.Log("Trying to hit you!");
       
        StartCoroutine(DoRotationAtTargetDirection(playerRef.transform));
        Collider[] hitboxes = Physics.OverlapSphere(hitpoint.position, hitRadius);


        Debug.Log(hitboxes.Length);
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
        if (health == 0)
        {
            Dead();
        }
        penLock = false;
    }

    public string Dead()
    {
       // Debug.Log("SHOULD BE FUCKING DEAD");
        Destroy(gameObject);
        return myName;
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
