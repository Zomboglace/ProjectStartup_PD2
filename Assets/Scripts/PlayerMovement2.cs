using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

        // Automatic forward movement (opposite direction)
        float forwardInput = -1f; // Opposite direction for forward movement
        Vector3 moveDirection = new Vector3(0f, 0f, forwardInput).normalized;
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);

        // Player left and right movement along the X-axis
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 horizontalMove = new Vector3(horizontalInput, 0f, 0f).normalized * moveSpeed;
        rb.velocity += horizontalMove;

        // Player left movement along the Z-axis
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        // Player right movement along the Z-axis
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        // Player jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }
}





