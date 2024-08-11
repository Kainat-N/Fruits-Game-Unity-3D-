using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int currentLevelIndex;
    private string currentLevelName;

    private void Start()
    {
        // Save the current level name
        currentLevelName = SceneManager.GetActiveScene().name;
        Debug.Log("currently playing " + currentLevelName);

        // Extract the level index from the current scene name (assuming all scene names are "Level1", "Level2", etc.)
        if (int.TryParse(currentLevelName.Replace("Level", ""), out currentLevelIndex))
        {
            // Save the current level index to PlayerPrefs
            PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex);
            PlayerPrefs.Save();
            Debug.Log("Currently playing Level" + currentLevelIndex);
        }
    }

    public void CompleteLevel()
    {
        // Load the "Level Completed" screen when the level is completed
        SceneManager.LoadScene("Level Completed");
    }
}
