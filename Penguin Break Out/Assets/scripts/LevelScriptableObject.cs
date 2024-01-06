
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelScriptableObject", menuName = "ScriptableObjects/Level")]
public class LevelScriptableObject : ScriptableObject
{
    public string LevelName; //name
    [HideInInspector]//for obvious reasons
    public bool Completed = false; //completed the level once already;

    public int group;
    public int hierarchy;
    
    public int monkeysRequired;// When this number is hit you will be sent back to the hub
    public int monkeysTotal; //if this number is the same as the unique monekys caught then you have 100% the level
    [HideInInspector]
    public int uniqueCaughtNum; // shows the number of monkeys  that were already caught
    [HideInInspector]
    public List<string> uniqueMonkeys; //names of unique monkeys
}
