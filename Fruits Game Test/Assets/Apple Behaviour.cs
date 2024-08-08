using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBehaviour : MonoBehaviour
{

    private int collisionCount = 0; // Counter for collisions with the floor

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the apple has collided with the floor
        if (collision.gameObject.CompareTag("Floor"))
        {
            collisionCount++; // Increment the collision count

            if (collisionCount >= 2)
            {
                // Start the coroutine to handle the delay
                StartCoroutine(DelayedDestroy(1f)); // 1-second delay
            }
        }
    }

    private IEnumerator DelayedDestroy(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Destroy the apple game object after the delay
        Destroy(gameObject);
    }
}
