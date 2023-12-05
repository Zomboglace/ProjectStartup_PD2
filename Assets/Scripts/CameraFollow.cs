using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float cameraZOffset = -5f; // Offset from the player's position along the z-axis
    public Vector3 cameraRotation = new Vector3(30f, 0f, 0f); // Rotation of the camera

    void Start()
    {
        if (player != null)
        {
            // Set the initial camera rotation based on the specified rotation
            transform.rotation = Quaternion.Euler(cameraRotation);
        }
        else
        {
            Debug.LogWarning("Player reference not set in CameraFollow script.");
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Update the camera's position along the z-axis to match the player's position with the specified offset
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, player.position.z + cameraZOffset);
            transform.position = newPosition;

            // Update the camera's rotation to match the specified rotation
            transform.rotation = Quaternion.Euler(cameraRotation);
        }
    }
}







