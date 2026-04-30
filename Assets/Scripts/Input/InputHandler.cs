using UnityEngine;
using UnityEngine.InputSystem;

/*
 * InputHandler
 * -----------
 * Captures and stores raw player input for use by PlayerMovement.
 * Uses Input System Package (Input Actions).
 */

public class InputHandler : MonoBehaviour
{
    /* 
     * INPUT ACTIONS
     * References to Input System actions defined in the Input Actions asset.
     */
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _jumpAction;

    /*
     * OUTPUT STATE
     * Processed input values exposed for gameplay systems.
     */
    public Vector2 MoveInput {  get; private set; }
    public float LastJumpPressedTime { get; private set; }

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();

        _moveAction = _playerInput.actions["Move"];
        _jumpAction = _playerInput.actions["Jump"];
    }

    /* 
     * ENABLE / DISABLE
     * Hooks and unhooks input events.
     */
    private void OnEnable()
    {
        _moveAction.Enable();
        _jumpAction.Enable();

        _jumpAction.started += OnJump;
    }

    private void OnDisable()
    {
        _moveAction.Disable();
        _jumpAction.Disable();

        _jumpAction.started -= OnJump;
    }

    /*
     * UPDATE
     * Reads movement input each frame from the Input System.
     */
    private void Update()
    {
        MoveInput = _moveAction.ReadValue<Vector2>();
    }

    /*
     * JUMP INPUT CALLBACK
     * Records timestamp for jump buffering logic.
     */
    private void OnJump(InputAction.CallbackContext context)
    {
        LastJumpPressedTime = Time.time;
    }
}
