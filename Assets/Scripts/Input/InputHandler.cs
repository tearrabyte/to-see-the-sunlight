using UnityEngine;

/*
 * InputHandler
 * -----------
 * Captures and stores raw player input for use by PlayerMovement.
 */

public class InputHandler : MonoBehaviour
{
    // Variables
    public float MoveInput {  get; private set; }
    public bool JumpPressed { get; private set; }
    public bool JumpReleased { get; private set; }

    // Unity Methods
    void Update()
    {
        HandleMovementInput();
        HandleJumpInput();
    }

    // Methods
    public void HandleMovementInput()
    {

    }

    public void HandleJumpInput()
    {

    }
}
