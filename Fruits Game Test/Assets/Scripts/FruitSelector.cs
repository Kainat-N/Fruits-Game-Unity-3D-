using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSelector:MonoBehaviour
{
    public Spawner spawner;
    public List<GameObject> fruits;

    public void SelectFruit(int index)
    {
        if (index >= 0 && index < fruits.Count)
        {
            if (index == 0) 
                Debug.Log("Apple Selected");
            if (index == 1)
                Debug.Log("Banana Selected");

            spawner.SetSpawnObject(fruits[index]);
        }
    }
}
