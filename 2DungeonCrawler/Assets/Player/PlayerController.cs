using UnityEngine;

public class PlayerController : MonoBehaviour
{
 public float moveSpeed = 5f; // Movement speed multiplier
    public float maxSpeed = 10f; // Maximum allowed speed for capping
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        // Getting reference to the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from arrow keys or WASD
        movement.x = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right arrow
        movement.y = Input.GetAxisRaw("Vertical");   // W/S or Up/Down arrow
    }

    void FixedUpdate()
    {
        // Set the Rigidbody's linearlinearVelocity based on input
        rb.linearVelocity = movement.normalized * moveSpeed;

        // Cap the linearVelocity if it exceeds maxSpeed
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
}
