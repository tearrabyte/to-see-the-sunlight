using UnityEngine;

/*
 * PlayerMovement
 * --------------
 * Controls player movement including directional movement and jumping.
 * Responsible for applying movement-related modifiers such as speed changes.
 */

public class PlayerMovement : MonoBehaviour
{
    // References
    public PlayerData data;
    public InputHandler input;

    // Components
    private Rigidbody2D _rb;

    // State
    public bool IsGrounded { get; private set; }

    // Methods
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        // Desired horizontal speed
        float targetSpeed = input.MoveInput.x * data.maxSpeed;

        // Select acceleration based on grounded or airborne state
        float accelRate;

        if(Mathf.Abs(targetSpeed) > 0.01f)
        {
            accelRate = IsGrounded ? data.groundAcceleration : data.airAcceleration;
        }
        else
        {
            accelRate = IsGrounded ? data.groundDeceleration : data.airDeceleration;
        }

        // Calculate difference between current and target speed
        float speedDiff = targetSpeed - _rb.linearVelocity.x;

        // Calculate and apply force
        float movement = speedDiff * accelRate;

        _rb.AddForce(movement * Vector2.right);
    }

    public void ApplyMovementModifier(Modifier modifier)
    {
        // Placeholder for future implementation.
    }
}
