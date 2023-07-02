using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableObject : MonoBehaviour
{
    public GameObject[] pensToLore;
    

    public void Lore() {

        foreach (GameObject p in pensToLore)
        {
            PinkPenguin pen = p.GetComponent<PinkPenguin>();
            pen.agent.SetDestination(transform.position);
        }
        tag = "Completed Interaction";
    }
}
