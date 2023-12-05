using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float constantForwardSpeed = 5f; // Positive for movement along the world Z-axis
    public float sidewaysSpeed = 7f;
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

        // Constant forward movement
        rb.velocity = new Vector3(0f, rb.velocity.y, -constantForwardSpeed); // Negative for opposite direction

        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(horizontalInput * sidewaysSpeed, 0f, 0f).normalized;
        rb.position += moveDirection * Time.deltaTime; // Move the player using position

        // Player jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }
}















