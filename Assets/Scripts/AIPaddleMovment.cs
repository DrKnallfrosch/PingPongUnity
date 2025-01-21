using UnityEngine;

public class AIPaddleMovment : MonoBehaviour
{
    readonly float _speed = 5.0f;
    public Transform ball;
    private Rigidbody2D _rb;

    // Grenzen für die Bewegung des Paddles
    private const float UpperLimit = 2.26f;
    private const float LowerLimit = -4.0f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Zielposition entlang der y-Achse
        float targetY = ball.position.y;

        // Paddle auf die Zielposition bewegen
        Vector2 newPosition = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, targetY), _speed * Time.fixedDeltaTime);

        // Begrenzung der y-Position mit Mathf.Clamp
        newPosition.y = Mathf.Clamp(newPosition.y, LowerLimit, UpperLimit);

        // Setze die Position des Paddles
        transform.position = newPosition;
    }
}
