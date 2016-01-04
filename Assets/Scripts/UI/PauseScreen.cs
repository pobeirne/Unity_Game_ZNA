using UnityEngine;

public class PauseScreen : GMBase
{
    public bool isPaused;
    public GameObject pauseMenuCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            Time.timeScale = 0.0f;
            pauseMenuCanvas.SetActive(true);            
        }

        if (!isPaused)
        {
            Time.timeScale = 1.0f;
            pauseMenuCanvas.SetActive(false);
           
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        isPaused = !isPaused;
    }

    public void QuitToMainMenu()
    {
        Application.LoadLevel(0);
    }
}
