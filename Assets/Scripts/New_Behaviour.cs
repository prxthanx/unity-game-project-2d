using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Movement speed of the player
    private Rigidbody2D rb;       // Reference to the Rigidbody2D

    void Start()
    {
        // Get the Rigidbody2D component attached to the player object
        rb = GetComponent<Rigidbody2D>();

        // Check if Rigidbody2D is found to prevent the null reference error
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing from the player object.");
        }
    }

    void Update()
    {
        // Get horizontal input (-1 for left, 1 for right, 0 for no input)
        float moveX = Input.GetAxis("Horizontal");

        // Check if moving left (moveX < -0.001)
        if (moveX < -0.001f)
        {
            // Set the player's local scale to (-1, 1, 1) to flip left
            transform.localScale = new Vector3(-1, 1, 1);
        }
        // Check if moving right (moveX > 0.001)
        else if (moveX > 0.001f)
        {
            // Set the player's local scale to (1, 1, 1) to face right
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void FixedUpdate()
    {
        // Move the player using Rigidbody2D
        if (rb != null)
        {
            float moveX = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        }
    }
}
