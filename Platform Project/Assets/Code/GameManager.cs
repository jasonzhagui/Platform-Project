using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PublicVars.paused)
            {
                pauseMenu.SetActive(false);
                PublicVars.paused = false;
                Time.timeScale = 1;

            }
            else
            {
                pauseMenu.SetActive(true);
                PublicVars.paused = true;
                Time.timeScale = 0;
            }

        }
        
    }
}
