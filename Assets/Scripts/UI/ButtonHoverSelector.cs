using UnityEngine;
using UnityEngine.EventSystems;

/*
 * ButtonHoverSelector
 * -------------------
 * Displays the selector indicators when the mouse hovers over a UI button.
 */

public class ButtonHoverSelector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Variables
    public GameObject leftSelector;
    public GameObject rightSelector;

    /*
     * POINTER ENTERS
     * Displays the selector indicators when the cursor enters the button area
     */

    public void OnPointerEnter(PointerEventData eventData)
    {
        leftSelector.SetActive(true);
        rightSelector.SetActive(true);
    }

    /*
     * POINTER EXITS
     * Hides the selector indicators when the cursor exits the button area
     */

    public void OnPointerExit(PointerEventData eventData)
    {
        leftSelector.SetActive(false);
        rightSelector.SetActive(false);
    }
}