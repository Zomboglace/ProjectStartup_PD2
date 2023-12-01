using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset = new Vector3(0f, 5f, -10f);
    public float smoothSpeed = 0.5f;

    void LateUpdate()
    {
        if (playerTransform != null)
        {
            Vector3 desiredPosition = playerTransform.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(playerTransform);
        }
    }
}

