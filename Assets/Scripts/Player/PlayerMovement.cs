using UnityEngine;

/*
 * PlayerMovement
 * --------------
 * Controls player movement including directional movement and jumping.
 * Responsible for applying movement-related modifiers such as speed changes.
 */

public class PlayerMovement : MonoBehaviour
{
    /* 
     * REFERENCES
     * External systems used by this script (input + data).
     */
    public PlayerData data;
    public InputHandler input;

    /* 
     * COMPONENTS
     * Unity components required for player movement.
     */
    private Rigidbody2D _rb;

    /* 
     * CHECKS
     * Provides grounded and wall contact state used by movement logic.
     */
    [Header("Ground Check")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Vector2 _groundCheckSize = new Vector2(0.8f, 0.15f);

    [Header("Wall Check")]
    [SerializeField] private Transform _frontWallCheck;
    [SerializeField] private Transform _backWallCheck;
    [SerializeField] private Vector2 _wallCheckSize = new Vector2(0.13f, 1.0f);

    public LayerMask groundLayer;

    /* 
     * STATE
     * Runtime flags utilised for movement logic decisions. 
     */
    public bool IsGrounded { get; private set; }
    public bool IsTouchingWallFront { get; private set; }
    public bool IsTouchingWallBack { get; private set; }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    /* 
     * FIXED UPDATE
     * Runs physics-based movement and environment checks.
     */
    private void FixedUpdate()
    {
        CheckGrounded();
        CheckWalls();
        HandleMovement();
    }

    /* 
     * MOVEMENT
     * Calculates target horizontal velocity based on input and max speed.
     * Applies acceleration depending on grounded or airborne state. 
     */
    private void HandleMovement()
    {
        float targetSpeed = input.MoveInput.x * data.maxSpeed;

        float accelerationRate;

        if(Mathf.Abs(targetSpeed) > 0.01f)
        {
            accelerationRate = IsGrounded ? data.groundAcceleration : data.airAcceleration;
        }
        else
        {
            accelerationRate = IsGrounded ? data.groundDeceleration : data.airDeceleration;
        }

        float speedDifference = targetSpeed - _rb.linearVelocity.x;

        float movementForce = speedDifference * accelerationRate;

        _rb.AddForce(movementForce * Vector2.right);
    }


    /* 
     * GROUND CHECK
     * Determines whether the player is currently grounded.
     * Affects movement control.
     */
    private void CheckGrounded()
    {
        IsGrounded = Physics2D.OverlapBox(
            _groundCheck.position,
            _groundCheckSize,
            0f,
            groundLayer
            );
    }

    /*
     * WALL CHECK
     * Detects walls on both sides of the player.
     * Foundation for future wall mechanics (jump, sliding etc.)
     */
    private void CheckWalls()
    {
        IsTouchingWallFront = Physics2D.OverlapBox(
            _frontWallCheck.position,
            _wallCheckSize,
            0f,
            groundLayer
        );

        IsTouchingWallBack = Physics2D.OverlapBox(
            _backWallCheck.position,
            _wallCheckSize,
            0f,
            groundLayer
            );
    }

    /*
     * DEBUG VISUALS
     * Draws ground and wall detection bounds.
     */
    private void OnDrawGizmosSelected()
    {
        if(_groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(_groundCheck.position, _groundCheckSize);
        }

        if (_frontWallCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(_frontWallCheck.position, _wallCheckSize);
        }

        if (_backWallCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(_backWallCheck.position, _wallCheckSize);
        }
    }

    public void ApplyMovementModifier(Modifier modifier)
    {
        // Placeholder for future implementation.
    }
}
