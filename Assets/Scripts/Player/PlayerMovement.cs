using UnityEngine;

/* 
 * PlayerMovement
 * --------------
 * Handles 2D character movement including grounded movement, jumping,
 * and mid-air movement shaping.
 * 
 * Jumping uses a velocity-based impulse derived from Physics2D.gravity,
 * ensuring consistent jump height independent of runtime gravity scaling.
 * 
 * GravityScale is used exclusively for mid-air movement shaping (jump cut, apex hang, fast fall).
 * It does not affect force calculation.
 */

public class PlayerMovement : MonoBehaviour
{
    /* 
     * REFERENCES
     * External systems required for movement logic.
     */
    [Header("References")]
    public PlayerData data;
    public InputHandler input;

    private Rigidbody2D _rb;

    /* 
     * STATE
     * Runtime movement state used for logic and animation integration.
     */
    [Header("State")]
    public bool IsFacingRight {  get; private set; }
    public bool IsJumping { get; private set; }
    public bool IsGrounded { get; private set; }
    public bool IsFalling { get; private set; }
    public bool IsAirborne { get; private set; }

    private float _coyoteTimer;
    private float _jumpBufferTimer;

    /* 
     * CHECKS
     * Physics overlap detection used for grounding and environment queries.
     */
    [Header("Checks")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Vector2 _groundCheckSize = new Vector2(0.8f, 0.15f);

    [Header("Layers")]
    [SerializeField] private LayerMask _groundLayer;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rb.gravityScale = data.gravityScale;
        IsFacingRight = false;
    }

    /* 
     * UPDATE
     * Handles input buffering and non-physics state updates.
     */
    private void Update()
    {
        HandleJumpBuffer();
        CheckGrounded();
        UpdateStates();
        HandleFacing();
        UpdateTimers();
    }

    /* 
     * FIXED UPDATE
     * Handles physics-based movement and jump execution.
     */
    private void FixedUpdate()
    {
        HandleMovement();
        HandleJump();
        HandleGravity();
        ClampFallSpeed();
    }

    /* 
     * MOVEMENT
     * Calculates target horizontal velocity based on input and acceleration rules. 
     */
    private void HandleMovement()
    {
        float targetSpeed = input.MoveInput.x * data.maxSpeed;

        bool isApex = !IsGrounded && Mathf.Abs(_rb.linearVelocity.y) < data.apexThreshold;

        float accelerationRate = Mathf.Abs(targetSpeed) > 0.01f
            ? (_coyoteTimer > 0 ? data.groundAcceleration : data.airAcceleration)
            : (_coyoteTimer > 0 ? data.groundDeceleration : data.airDeceleration);

        if(isApex)
        {
            accelerationRate *= data.apexAccelerationMultiplier;
            targetSpeed *= data.apexSpeedMultiplier;
        }

        float smoothFactor = 1f - Mathf.Exp(-accelerationRate * Time.fixedDeltaTime);
        float horizontalVelocity = Mathf.Lerp(_rb.linearVelocity.x, targetSpeed, smoothFactor);

        _rb.linearVelocity = new Vector2(horizontalVelocity, _rb.linearVelocity.y);
    }


    /* 
     * JUMP
     * Applies upward velocity based on jumpHeight when buffered input and coyote time conditions are met.
     */
    private void HandleJump()
    {
        if (!CanJump()) return;

        _jumpBufferTimer = 0f;
        _coyoteTimer = 0f;

        float jumpVelocity = Mathf.Sqrt(2f * Mathf.Abs(Physics2D.gravity.y) * data.jumpHeight);

        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpVelocity);
    }

    /* 
     * GRAVITY SHAPING
     * Dynamically modifies Rigidbody gravityScale to control jump feel.
     */
    private void HandleGravity()
    {
        float yVelocity = _rb.linearVelocity.y;
        float baseGravity = data.gravityScale;
        float targetGravity = baseGravity;

        // Jump Cut (early release = higher gravity)
        if(!input.JumpHeld && yVelocity > 0.01f)
        {
            targetGravity = baseGravity * data.jumpCutGravityMultiplier;
        }

        // Apex Hang Time (low vertical speed while holding jump)
        else if(input.JumpHeld && Mathf.Abs(yVelocity) < data.apexThreshold)
        {
            targetGravity = baseGravity * data.apexGravityMultiplier;
        }

        // Faster Fall (descending gravity boost)
        else if(yVelocity < 0f)
        {
            targetGravity = baseGravity * data.fallGravityMultiplier;
        }

        if (_rb.gravityScale != targetGravity)
        {
            _rb.gravityScale = targetGravity;
        }
    }

    /* 
    * CLAMP FALL SPEED
    * Prevents terminal velocity from exceeding design limits for consistent jump/fall feel.
    */
    private void ClampFallSpeed()
    {
        if(_rb.linearVelocity.y < -data.maxFallSpeed)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, -data.maxFallSpeed);
        }
    }


    /* 
     * HANDLE JUMP BUFFER
     * Stores jump input briefly to allow forgiving jump timing.
     */
    private void HandleJumpBuffer()
    {
        if (input.JumpPressed)
        {
            _jumpBufferTimer = data.jumpBufferTime;
        }
    }
    /* 
     * GROUND CHECK
     * Refreshes coyote timer when grounded.
     */
    private void CheckGrounded()
    {
        IsGrounded = Physics2D.OverlapBox(_groundCheck.position, _groundCheckSize, 0f, _groundLayer);

        if(IsGrounded)
        {
            _coyoteTimer = data.coyoteTime;
        }
    }

    /* 
     * UPDATE STATES
     * Derives high-level movement state from physics values.
     * Used for animation.
     */
    public void UpdateStates()
    {
        IsFalling = !IsGrounded && _rb.linearVelocity.y < -0.1f;
        IsJumping = !IsGrounded && _rb.linearVelocity.y > 0.1f;
        IsAirborne = !IsGrounded;
    }

    /* 
     * TIMERS
     * Handles decay of temporary movement forgiveness values.
     */
    public void UpdateTimers()
    {
        _coyoteTimer -= Time.deltaTime;
        _jumpBufferTimer -= Time.deltaTime;
    }

    /* 
     * PLAYER FACING
     * Handles sprite orientation based on movement direction.
     */
    public void HandleFacing()
    {
        if (input.MoveInput.x == 0) return;

        bool movingRight = input.MoveInput.x > 0f;

        if (movingRight != IsFacingRight)
        {
            Turn();
        }
    }

    private void Turn()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        IsFacingRight = !IsFacingRight;
    }

    /* 
     * JUMP RULE
     * Determines whether jump conditions are valid.
     */
    private bool CanJump()
    {
        return _jumpBufferTimer > 0f && _coyoteTimer > 0f;
    }

    public void ApplyMovementModifier(Modifier modifier)
    {
        // Placeholder for future implementation.
    }

    /*
    * DEBUG VISUALS
    * Ground detection visualisation.
    */
    private void OnDrawGizmosSelected()
    {
        if (_groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(_groundCheck.position, _groundCheckSize);
        }
    }
}
