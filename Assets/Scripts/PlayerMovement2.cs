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
        
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

        
        float forwardInput = -1f; 
        Vector3 moveDirection = new Vector3(0f, 0f, forwardInput).normalized;
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);

        
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 horizontalMove = new Vector3(horizontalInput, 0f, 0f).normalized * moveSpeed;
        rb.velocity += horizontalMove;

        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }
}





