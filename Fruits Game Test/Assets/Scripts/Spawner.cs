using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Vector3 SpawnPos;
    public Transform SpawnPlaceHolder;
    public GameObject spawnObject;
    private float newSpawnDuration = 1.0f;

    public FruitSelector fruitSelector; // Reference to the FruitSelector
    public float spawnInterval = 2f; // Time between spawns

    private GameObject currentFruit; // Reference to the currently spawned fruit
    public float positionTolerance = 0.2f;

    #region Singleton

    public static Spawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    private void Start()
    {
        SpawnPos = SpawnPlaceHolder.position;
        SpawnNewObject();
    }

    public void SetSpawnObject(GameObject newSpawnObject)
    {
        // Destroy the current fruit at the spawn position (if any)
        if (currentFruit != null && IsAtSpawnPosition(currentFruit))
        {
            Destroy(currentFruit);
        }

        spawnObject = newSpawnObject;
        SpawnNewObject();
    }

    private bool IsAtSpawnPosition(GameObject fruit)
    {
        // Get the collider bounds
        Collider fruitCollider = fruit.GetComponent<Collider>();
        if (fruitCollider != null)
        {
            Bounds bounds = fruitCollider.bounds;
            float bottomY = bounds.min.y;

            // Check if the bottom of the fruit is at or near the spawn position
            if (Mathf.Abs(bottomY - SpawnPos.y) < positionTolerance)
            {
                return true;
            }
        }
        return false;
    }

    private void SpawnNewObject()
    {
        // Destroy the current fruit at the spawn position (if any)
        if (currentFruit != null && IsAtSpawnPosition(currentFruit))
        {
            Destroy(currentFruit);
        }

        // Instantiate the new fruit
        currentFruit = Instantiate(spawnObject, SpawnPos, Quaternion.identity);

        // Set specific rotation for the banana (or other fruits if needed)
        if (spawnObject.name == "Banana")
        {
            currentFruit.transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        DragAndShoot dragAndShoot = currentFruit.GetComponent<DragAndShoot>();
        if (dragAndShoot != null)
        {
            dragAndShoot.spawner = this; // Set the reference to this Spawner instance
        }
    }

    public void NewSpawnRequest()
    {
        Invoke("SpawnNewObject", newSpawnDuration);
    }
}
