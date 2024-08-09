using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class IntroScreenManager : MonoBehaviour
{
    public Image introImage; // Reference to the UI Image component
    public float introDuration = 3f; // Duration of the intro screen

    private void Start()
    {
        if (introImage != null)
        {
            // Start the intro screen display
            StartCoroutine(ShowIntroScreen());
        }
    }

    private IEnumerator ShowIntroScreen()
    {
        // Show the intro image
        introImage.gameObject.SetActive(true);

        // Wait for the duration of the intro screen
        yield return new WaitForSeconds(introDuration);

        // Hide the intro image
        introImage.gameObject.SetActive(false);

        // Optionally, load the main menu or the next scene
        SceneManager.LoadScene("Level 1"); // Replace with your next scene name
    }
}
