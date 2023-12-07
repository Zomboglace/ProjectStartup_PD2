using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; 
    public float cameraZOffset = -5f; 
    public Vector3 cameraRotation = new Vector3(30f, 0f, 0f); 

    void Start()
    {
        if (player != null)
        {
            
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
            
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, player.position.z + cameraZOffset);
            transform.position = newPosition;

            
            transform.rotation = Quaternion.Euler(cameraRotation);
        }
    }
}







