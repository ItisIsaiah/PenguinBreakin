using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableObject : MonoBehaviour
{
    public GameObject[] pensToLore;
    Collider[] colliders;
    public Collider s;

    public void Start()
    {
        colliders = GetComponent<Collider[]>();
        foreach( Collider c in colliders)
        {
            if (c.isTrigger)
            {
                s = c;
            }
        }
    }
    public void Lore() {

        s.enabled = false;
        foreach (GameObject p in pensToLore)
        {
            PinkPenguin pen = p.GetComponent<PinkPenguin>();
            pen.agent.SetDestination(transform.position);
        }
        tag = "Completed Interaction";
    }
}
