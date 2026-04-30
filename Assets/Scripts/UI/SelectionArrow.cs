using UnityEngine;
using UnityEngine.InputSystem;

/*
 * SelectionArrow
 * ---------
 * Moves selection arrow up and down with selection option, mouse howering and up & down
 */

public class SelectionArrow : MonoBehaviour
{
    //rect is transform for reposition, options are all variants for a button to point
    //currentpos is for the current selection
    private RectTransform rect;
    [SerializeField] private RectTransform[] options;
    private int currentPosition;

    private PlayerInputActions inputActions;
    /*
     AWAKE
     Creates input actions instance from rect 
     */
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        inputActions = new PlayerInputActions();
    }
    /*
     ENABLE/DISABLE
     Connects to navigate input event, prevents ghost calls for incative object
     */
    private void OnEnable()
    {
        inputActions.UI.Enable();
        inputActions.UI.Navigate.performed += OnNavigate;
    }
    private void OnDisable()
    {
        inputActions.UI.Navigate.performed -= OnNavigate;
        inputActions.UI.Disable();
    }
    /*
     NAVIGATE
     Reads vertical axis and moves selection alongside (vector2 = x & y)
     */
    private void OnNavigate(InputAction.CallbackContext ctx)
    {
        Vector2 input = ctx.ReadValue<Vector2>();

        if (input.y < 0) ChangePosition(1);
        else if (input.y > 0) ChangePosition(-1);
    }
    /*
     CHANGE POSITION
     Moves the selection by a given amount and wraps around if the top or bottom of the list is exceeded
     */
    private void ChangePosition(int change)
    {
        currentPosition += change;

        if (currentPosition < 0)
            currentPosition = options.Length - 1;
        else if (currentPosition > options.Length - 1)
            currentPosition = 0;

        rect.localPosition = new Vector3(rect.localPosition.x, options[currentPosition].localPosition.y, 0);
    }
    /*
     SET POSITION
     Jumps the arrow directly to a specific index
     */
    public void SetPosition(int index)
    {
        currentPosition = index;
        rect.localPosition = new Vector3(rect.localPosition.x, options[currentPosition].localPosition.y, 0);
    }
}