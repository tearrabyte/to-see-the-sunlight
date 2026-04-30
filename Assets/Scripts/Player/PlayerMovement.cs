using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

/*
 * PlayerMovement
 * --------------
 * Handles horizontal movement and jumping behaviour.
 * Responsible for applying movement-related modifiers such as speed changes.
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

    private float _coyoteTimer;
    private bool _hasJumpBuffered;

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
        SetGravityScale(data.gravityScale);
        IsFacingRight = false;
    }

    /* 
     * UPDATE
     * Handles input buffering and non-physics state updates.
     */
    private void Update()
    {
        // Jump buffer window check
        if(Time.time - input.LastJumpPressedTime <= data.jumpBufferTime)
        {
            _hasJumpBuffered = true;
        }

        CheckGrounded();

        if (input.MoveInput.x != 0)
        {
            CheckFacing(input.MoveInput.x > 0);
        }

        UpdateTimers();
    }

    /* 
     * FIXED UPDATE
     * Handles physics-based movement and jump execution.
     */
    private void FixedUpdate()
    {
        HandleJump();
        HandleMovement();
    }

    /* 
     * MOVEMENT
     * Calculates target horizontal velocity based on input and acceleration rules. 
     */
    private void HandleMovement()
    {
        float targetSpeed = input.MoveInput.x * data.maxSpeed;

        float accelerationRate = Mathf.Abs(targetSpeed) > 0.01f
            ? (_coyoteTimer > 0 ? data.groundAcceleration : data.airAcceleration)
            : (_coyoteTimer > 0 ? data.groundDeceleration : data.airDeceleration);

        float speedDifference = targetSpeed - _rb.linearVelocity.x;
        float movementForce = speedDifference * accelerationRate;

        _rb.AddForce(movementForce * Vector2.right);
    }


    /* 
     * JUMP
     * Executes jump if buffer and coyote time conditions are met.
     */
    private void HandleJump()
    {
        if (!_hasJumpBuffered || !CanJump()) return;

        _hasJumpBuffered = false;

        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, 0f);
        _rb.AddForce(data.jumpForce * Vector2.up, ForceMode2D.Impulse);
    }

    /* 
     * GROUND CHECK
     * Refreshes coyote timer when grounded.
     */
    private void CheckGrounded()
    {
        if(Physics2D.OverlapBox(_groundCheck.position, _groundCheckSize, 0f, _groundLayer))
        {
            _coyoteTimer = data.coyoteTime;
        }
    }

    /* 
     * TIMERS
     * Handles decay of temporary movement forgiveness values.
     */
    public void UpdateTimers()
    {
        _coyoteTimer -= Time.deltaTime;
    }

    /* 
     * GRAVITY SETUP
     * Syncs Rigidbody2D gravity with PlayerData.
     */
    public void SetGravityScale(float scale)
    {
        _rb.gravityScale = scale;
    }

    /* 
     * PLAYER FACING
     * Handles sprite orientation based on movement direction.
     */
    public void CheckFacing(bool movingRight)
    {
        if(movingRight != IsFacingRight)
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
        return _coyoteTimer > 0;
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
