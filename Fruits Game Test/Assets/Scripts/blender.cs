using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blender : MonoBehaviour
{
    public OrderManager orderManager; // Reference to the OrderManager

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit")) // Ensure all fruit objects have the "Fruit" tag
        {
            string fruitName = other.gameObject.name.Replace("(Clone)", "").Trim();
            Destroy(other.gameObject); // Destroy the fruit
            orderManager.OnFruitInBlender(fruitName);
            
        }
    }
}

