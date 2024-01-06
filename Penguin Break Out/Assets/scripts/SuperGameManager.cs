using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuperGameManager : MonoBehaviour
{
    public List<LevelScriptableObject> levels;
    int totalGroups;
    int levelsPerGroup;


    #region SingleTon
    public static SuperGameManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        DontDestroyOnLoad(this);
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Save()
    {

    }

    void Load()
    {

    }
    public void copyData(LevelScriptableObject dataToReplace)
    {
        foreach (LevelScriptableObject s in levels)
        {
            if (s.LevelName == dataToReplace.LevelName)
            {
                levels.Remove(s);
            }
            
        }
        levels.Add(dataToReplace);
    }

    public void checkToEnter(LevelScriptableObject levelToEnter)
    {
        foreach (LevelScriptableObject l in levels)
        {
            if (l.LevelName == levelToEnter.LevelName)
            {
                continue;
            }
            if (l.group==levelToEnter.group)
            {
                if (l.hierarchy < levelToEnter.hierarchy && !l.Completed)
                //see if the other guy in your group was satisfied.

                {
                    Debug.Log("CANNOT ENTER");
                    return;
                }
                else
                {
                    SceneManager.LoadScene(levelToEnter.LevelName);
                }
            }
            
        }
        Debug.LogWarning("This level doesnt exist");
    }

    public LevelScriptableObject copyDataFrom(LevelScriptableObject dataToReplace)
    {
        foreach (LevelScriptableObject s in levels)
        {
            if (s.LevelName == dataToReplace.LevelName)
            {
                return s;
            }

        }

        Debug.LogError(dataToReplace.LevelName + ": IS NOT A VALID LEVEL. FIX IT."); 
        return null;

    }
}
