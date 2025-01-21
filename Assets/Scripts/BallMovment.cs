using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the ball
    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component attached to the ball
        rb = GetComponent<Rigidbody2D>();

        // Launch the ball in a random direction at the start
        LaunchBall();
    }

    void LaunchBall()
    {
        // Determine the initial direction of the ball
        bool isRightSide = Random.value > 0.5f; // Randomly decide if the ball starts towards the right paddle or left
        float randomAngle = Random.Range(45f, 60f) * (isRightSide ? -1 : 1); // Randomize angle between 45° and 60°

        // Convert angle to direction vector
        Vector2 direction = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));

        // Set the initial velocity
        rb.linearVelocity = direction.normalized * speed;
    }

    void FixedUpdate()
    {
        // Ensure the ball maintains a consistent speed
        rb.linearVelocity = rb.linearVelocity.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the ball hit a paddle or wall
        if (collision.gameObject.CompareTag("Paddle"))
        {
            speed += 0.525f;
        }
    }

    void HandlePaddleCollision(Collision2D collision)
    {
        // Calculate the bounce direction based on where the ball hit the paddle
        Vector2 paddlePosition = collision.transform.position;
        Vector2 contactPoint = collision.GetContact(0).point;
        float paddleHeight = collision.collider.bounds.size.y;

        // Determine how far from the paddle's center the collision occurred
        float offset = contactPoint.y - paddlePosition.y;
        float normalizedOffset = offset / (paddleHeight / 2);

        // Adjust the ball's velocity to ensure it changes direction
        Vector2 currentVelocity = rb.linearVelocity;
        float directionX = -Mathf.Sign(currentVelocity.x); // Reverse the X direction

        // Calculate the new bounce direction
        Vector2 bounceDirection = new Vector2(directionX, normalizedOffset).normalized;

        // Apply the new velocity
        rb.linearVelocity = bounceDirection * speed;
    }
}
