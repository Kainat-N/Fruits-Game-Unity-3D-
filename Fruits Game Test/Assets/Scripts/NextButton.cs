using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    public Button nextButton; // Reference to the Button component

    private void Start()
    {
        // Set up the button listener
        nextButton.onClick.AddListener(LoadNextLevel);
    }

    void LoadNextLevel()
    {
        // Logic to load the next level
        // This could be a scene index or name, e.g.:
        SceneManager.LoadScene("NextLevelScene");
    }
}
