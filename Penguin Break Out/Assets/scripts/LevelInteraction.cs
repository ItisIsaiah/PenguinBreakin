using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInteraction : MonoBehaviour
{
    public LevelScriptableObject lvl;
    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        SuperGameManager.Instance.checkToEnter(lvl);  
    }
}
