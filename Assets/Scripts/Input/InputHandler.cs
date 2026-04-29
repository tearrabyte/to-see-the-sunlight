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
    private InputAction _moveAction;
    private InputAction _jumpAction;

    /*
     * OUTPUT STATE
     * Processed input values exposed for use by gameplay systems
     */
    public Vector2 MoveInput {  get; private set; }
    public bool JumpPressed { get; private set; }
    public bool JumpHeld { get; private set; }
    public bool JumpReleased { get; private set; }

    private void Awake()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();

        _moveAction = playerInput.actions.FindAction("Move");
        _jumpAction = playerInput.actions.FindAction("Jump");
    }

    /* 
     * ENABLE/DISABLE INPUT ACTIONS
     * Enables and disables input actions based on active/inactive state of the object
     */
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

    /*
     * UPDATE
     * Reads current input state from Input System each frame.
     */
    private void Update()
    {
        MoveInput = _moveAction.ReadValue<Vector2>();

        JumpPressed = _jumpAction.WasPressedThisFrame();
        JumpHeld = _jumpAction.IsPressed();
        JumpReleased = _jumpAction.WasReleasedThisFrame();
    }
}
