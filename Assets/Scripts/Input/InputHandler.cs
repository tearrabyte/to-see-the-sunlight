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
    // Input Actions
    private InputAction _moveAction;
    private InputAction _jumpAction;

    // Output State
    public Vector2 MoveInput {  get; private set; }
    public bool JumpPressed { get; private set; }
    public bool JumpHeld { get; private set; }
    public bool JumpReleased { get; private set; }

    // Unity Methods
    private void Awake()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();

        _moveAction = playerInput.actions["Move"];
        _jumpAction = playerInput.actions["Jump"];
    }

    private void OnEnable()
    {
        _moveAction.Enable();
        _jumpAction.Enable();
    }
    private void OnDisable()
    {
        _moveAction.Disable();
        _jumpAction.Disable();
    }

    public void Update()
    {
        MoveInput = _moveAction.ReadValue<Vector2>();

        JumpPressed = _jumpAction.WasPressedThisFrame();
        JumpHeld = _jumpAction.IsPressed();
        JumpReleased = _jumpAction.WasReleasedThisFrame();
    }
}
