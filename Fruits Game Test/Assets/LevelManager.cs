using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button nextButton; // Reference to the Next Button
    private int currentLevelIndex;

    private void Start()
    {
        // Get the current level index from PlayerPrefs or initialize it
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);

        // Set up the button listener
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(LoadNextLevel);
        }
    }

    public void LoadNextLevel()
    {
        // Calculate the next level index
        int nextLevelIndex = currentLevelIndex + 1;

        // Check if the next level index is within the valid range
        if (nextLevelIndex <= 5) // Assuming you have 5 levels
        {
            // Save the next level index
            PlayerPrefs.SetInt("CurrentLevelIndex", nextLevelIndex);
            PlayerPrefs.Save();

            // Load the next level scene
            SceneManager.LoadScene("Level" + nextLevelIndex);
        }
        else
        {
            // Optionally, handle what happens after the final level is completed
            // For example, load a "Congratulations" or "Game Completed" scene
            SceneManager.LoadScene("GameCompletedScene");
        }
    }
}

