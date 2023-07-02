using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pmUI;
    private void Start()
    {
        pmUI.SetActive(false);
    }
    public void PauseSwitch()
    {
        Debug.Log("RECIEVED SIGNAL");
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    void Resume()
    {
        pmUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

  void Pause()
    {
        pmUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

}
