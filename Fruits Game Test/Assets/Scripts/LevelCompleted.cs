using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletedManager : MonoBehaviour
{
    public void OnNextButtonPressed()
    {
        // Retrieve the next level index from PlayerPrefs
        int nextLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1) + 1;
        Debug.Log("Next level should be Level" + nextLevelIndex);

        // Get the scene path for the next level
        string nextLevelName = "Level" + nextLevelIndex;
        int buildIndex = SceneUtility.GetBuildIndexByScenePath(nextLevelName);

        // Check if the scene exists in the build settings
        if (buildIndex != -1)
        {
            Debug.Log("Next level exists, loading Level" + nextLevelIndex);
            // Load the next level
            SceneManager.LoadScene(nextLevelName);
        }
        else
        {
            Debug.Log("Next level does not exist, loading GameCompletedScene");
            // If the next level doesn't exist, load the Game Completed screen
            SceneManager.LoadScene("Game Completed");
        }
    }
}
