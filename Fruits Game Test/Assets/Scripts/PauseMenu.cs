using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;



    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Home() {
        SceneManager.LoadSceneAsync("LevelScreen");
        Time.timeScale = 1.0f;
    }

    public void Restart() 
    {
        //Debug.Log("Retry button pressed, reloading level...");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;

    }


    public void Retry()
    {
        if (!string.IsNullOrEmpty(LevelManager.previousLevelName))
        {
            Debug.Log("Retrying level: " + LevelManager.previousLevelName);
            SceneManager.LoadScene(LevelManager.previousLevelName);
            Time.timeScale = 1.0f;  // Ensure the game time is running normally
        }
        else
        {
            Debug.LogWarning("No previous level stored!");
        }
    }

}
