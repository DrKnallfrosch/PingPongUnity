using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f; // Geschwindigkeit des Paddels
    private const float UpLimit = 2.26f; // Grenzen der Bewegung entlang der Y-Achse
    private const float DownLimit = -4f; // Grenzen der Bewegung entlang der Y-Achse

    private InputAction _moveAction;
    private float _input;

    private void Awake()
    {
        // PlayerInput-Komponente abrufen
        var playerInput = GetComponent<PlayerInput>();

        // Bewegungseingabe aus der Action Map abrufen
        _moveAction = playerInput.actions["Move"];
        _moveAction.Enable();
    }

    private void Update()
    {
        if (_moveAction == null) return;

        // Spieler-Input abfragen
        _input = _moveAction.ReadValue<float>();
        // Bewegung berechnen
        Vector3 movement = new Vector3(0, _input * speed * Time.deltaTime, 0);
        // Position aktualisieren
        transform.position += movement;
        // Bewegung begrenzen
        float clampedY = Mathf.Clamp(transform.position.y, DownLimit, UpLimit);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}