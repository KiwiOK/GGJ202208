using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    private Canvas pauseMenu;

    void Start()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("Pausa").GetComponent<Canvas>() ;
        pauseMenu.enabled = false;
    }
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameIsPaused)
                PauseGame();
            else
                ResumeGame();
        }
    }
    public void PauseGame()
    {
        pauseMenu.enabled = true;
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.enabled = false;
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void Quit() { Application.Quit(); }
}
