using UnityEngine;
using UnityEngine.EventSystems;

/*
 * MOUSE HANDLER
 * Detects when the mouse hovers over a menu button and moves
 * both selection arrows to match that button's position.
 */

public class MouseHandler : MonoBehaviour, IPointerEnterHandler
{
    //we have 2 arrows, index shows which buttons to hover over
    [SerializeField] private SelectionArrow arrowLeft;
    [SerializeField] private SelectionArrow arrowRight;
    [SerializeField] private int index;

    /*
     ON POINTER ENTER
     Starts when the mouse enters this button's area, moves both arrows to this button's index in the options list
     */
    public void OnPointerEnter(PointerEventData eventData)
    {
        arrowLeft.SetPosition(index);
        arrowRight.SetPosition(index);
    }
}
