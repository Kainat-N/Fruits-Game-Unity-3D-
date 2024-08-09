using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Order
{
    public List<string> fruits; // List of fruit names for this order
}

public class OrderManager : MonoBehaviour
{
    public List<Order> orders; // List of orders
    private int currentOrderIndex = 0;
    private Order currentOrder;
    private int score = 0;
    public int pointsPerOrder = 1;
    public float levelTime = 60f; // Time for the level
    private float timeRemaining;
    private bool levelEnded = false; // Flag to check if the level has ended

    // UI References
    public TMP_Text orderText;
    public TMP_Text scoreText;
    public TMP_Text timeText;

    void Start()
    {
        timeRemaining = levelTime;
        LoadNextOrder();
        UpdateScoreUI();
    }

    void Update()
    {
        if (levelEnded) return; // Stop updating if the level has ended

        timeRemaining -= Time.deltaTime;
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
            // All orders completed
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

            if (currentOrder.fruits.Count == 0)
            {
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

    void UpdateTimeUI()
    {
        timeText.text = "" + Mathf.Ceil(timeRemaining).ToString();
    }

    void EndLevel()
    {
        levelEnded = true; // Mark the level as ended
        Debug.Log("Level Ended. Score: " + score);

        // Optionally load the next screen or level here
        // For example, you can use Unity's SceneManager to load the next scene:
        // UnityEngine.SceneManagement.SceneManager.LoadScene("NextSceneName");

        // Alternatively, you could trigger a UI screen, animation, or anything else
        // you want to happen at the end of the level.
    }
}
