
using UnityEngine;
[CreateAssetMenu(fileName = "PenguinScriptableObject",menuName = "ScriptableObjects/Penguin")]
public class PenguinScriptableObject : ScriptableObject
{
    public string myName;
    public int health = 3;
    public bool scared = false;
    public float speed = 5f;
    public bool aggressive = false;
}
