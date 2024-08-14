using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Order
{
    public List<string> fruits; // List of fruit names for this order
}

public class OrderManager : MonoBehaviour
{
    public List<Order> orders; // List of orders

    private int completedOrders = 0; // Track the number of completed orders

    private int currentOrderIndex = 0;
    private Order currentOrder;
    private int score = 0;
    public int pointsPerOrder = 1;
    public float levelTime = 60f; // Time for the level
    private float timeRemaining;
    private bool levelEnded = false; // Flag to check if the level has ended
    public LevelManager levelManager; // Reference to LevelManager

    // UI References
    public TMP_Text orderText;
    public TMP_Text scoreText;
    public TMP_Text orderCountText;
    [SerializeField] TextMeshProUGUI timeText;

    //Audio References
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip correctFruitSound; // Sound effect for correct fruit landing
    public AudioClip orderCompletedSound; // Sound effect for order completed
    public AudioClip levelFailedSound; // Sound effect for level completed


    void Start()
    {
        timeRemaining = levelTime;
        UpdateOrderCountUI();
        LoadNextOrder();
        UpdateScoreUI();
    }

    void Update()
    {
        if (levelEnded) return; // Stop updating if the level has ended

        if (timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
        }
    
        UpdateTimeUI();

        if (timeRemaining <= 0)
        {
            EndLevel();
        }
    }

    void LoadNextOrder()
    {
        if (currentOrderIndex < orders.Count)
        {
            currentOrder = orders[currentOrderIndex];
            currentOrderIndex++;
            UpdateOrderUI();
        }
        else
        {
           EndLevel();
        }
    }

    public void OnFruitInBlender(string fruitName)
    {
        if (currentOrder.fruits.Contains(fruitName))
        {
            currentOrder.fruits.Remove(fruitName);
            score += pointsPerOrder;
            UpdateScoreUI();

            


            // Check if this is the last fruit for the current order
            bool isLastFruit = currentOrder.fruits.Count == 0;

            // Play sound effect for correct fruit landing, if it's not the last fruit
            if (!isLastFruit && audioSource != null && correctFruitSound != null)
            {
                audioSource.PlayOneShot(correctFruitSound);
            }

            if (isLastFruit)
            {
                completedOrders++; // Increment the count of completed orders
                UpdateOrderCountUI(); // Update the UI

                // Play sound effect for order completion
                if (audioSource != null && orderCompletedSound != null)
                {
                    audioSource.PlayOneShot(orderCompletedSound);
                }

                    //------------------------------------------------
                    LoadNextOrder();
            }
        }
        else
        {
            // Handle incorrect fruit in blender, if needed
        }
    }

    void UpdateOrderUI()
    {
        orderText.text = "" + string.Join(", ", currentOrder.fruits);
    }

    void UpdateScoreUI()
    {
        scoreText.text = "" + score;
    }

    void UpdateOrderCountUI()
    {
        orderCountText.text = $"{completedOrders}/{orders.Count}"; // Display completed/total orders
    }

    void UpdateTimeUI()
    {
        
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void EndLevel()
    {
        levelEnded = true; // Mark the level as ended
        Debug.Log("Level Ended. Score: " + score);
        
        // Check if there are any remaining orders
        if (currentOrderIndex < orders.Count || currentOrder.fruits.Count > 0)
        {
            // Orders are not completed, load "LevelFailed" scene
            levelManager.StoreCurrentLevel();


            // Play the level completed sound
            if (audioSource != null && levelFailedSound != null)
            {
                audioSource.PlayOneShot(levelFailedSound);
            }

            SceneManager.LoadScene("Level Failed");
        }
        else
        {
            // All orders completed just in time, load "LevelCompleted" scene
            // SceneManager.LoadScene("Level Completed");
            if (levelManager != null)
            {
                levelManager.CompleteLevel();
            }
        }
    }
}
