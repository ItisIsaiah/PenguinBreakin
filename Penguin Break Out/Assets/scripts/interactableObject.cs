using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableObject : MonoBehaviour
{
    public GameObject[] pensToLore;
  //  Collider[] colliders;
    public Collider s;

    public void Start()
    {
       
    }
    //Used to Lore the penguins after the player interacts with the item.
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
