using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int currentLevelIndex;
    public string currentLevelName;

    public static string previousLevelName;


    // Audio Components
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip levelCompletedSound; // Sound effect for level completed

    // Call this method before loading the "Level Failed" screen
    public void StoreCurrentLevel()
    {
        previousLevelName = SceneManager.GetActiveScene().name;
    }

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
        // Play the level completed sound
        if (audioSource != null && levelCompletedSound != null)
        {
            audioSource.PlayOneShot(levelCompletedSound);
        }


        // Load the "Level Completed" screen when the level is completed
        SceneManager.LoadScene("Level Completed");
    }
}
