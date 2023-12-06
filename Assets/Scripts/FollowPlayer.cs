using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float followSpeed = 5f;  // Speed at which the object follows the player

    void Update()
    {
        if (player != null)
        {
            // Calculate the direction from the current position to the player's position
            Vector3 direction = player.position - transform.position;

            // Normalize the direction vector to ensure consistent movement speed
            direction.Normalize();

            // Move the object towards the player
            transform.position += direction * followSpeed * Time.deltaTime;
        }
        else
        {
            Debug.LogWarning("Player reference not set. Please assign the player GameObject in the inspector.");
        }
    }
}

