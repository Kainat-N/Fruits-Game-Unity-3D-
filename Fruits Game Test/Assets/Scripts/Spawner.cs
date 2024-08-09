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
        spawnObject = newSpawnObject;
        Start();
        //SpawnNewObject();
    }



    private void SpawnNewObject()
    {
        // Destroy the currently spawned fruit if it exists
        if (currentFruit != null && currentFruit.transform.position.y >= SpawnPos.y)
        {
            Destroy(currentFruit);
        }

        
        currentFruit = Instantiate(spawnObject, SpawnPos, Quaternion.identity);
        //Instantiate(spawnObject, SpawnPos, Quaternion.identity);

        // Set specific rotation for banana (or other fruits if needed)
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