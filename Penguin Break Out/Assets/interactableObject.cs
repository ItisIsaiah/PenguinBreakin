using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableObject : MonoBehaviour
{
    GameObject[] pensToLore;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMove p = other.GetComponent<PlayerMove>();
            p.interactionCheck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMove p = other.GetComponent<PlayerMove>();
            p.interactionCheck = false;
        }
    }

    void Lore() {

        foreach (GameObject p in pensToLore)
        {
            PinkPenguin pen = p.GetComponent<PinkPenguin>();
            pen.agent.SetDestination(transform.position);
        }
    }
}
