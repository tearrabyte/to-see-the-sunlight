using UnityEngine;

/*
 * Menu
 * ----
 * Base class for all UI menus displayed outside of active gameplay.
 * Provides common functionality for opening, closing, and toggling UI panels.
 */

// The menu is the base class for all menu panels utilized in our project to ensure
// that consistent opening and closing logic occurs for the menu base class.

public abstract class Menu : MonoBehaviour
{
    // Variables
    public bool isOpen;
    public string menuName;

    //Methods

    /*
     OPEN
     Marks the menu as open and activates its game object
    */
    public virtual void Open()
    {
        isOpen = true;
        gameObject.SetActive(true);
    }
    /*CLOSE
      Marks the menu as closed and deactivates its game object
    */
    public virtual void Close()
    {
        isOpen = false;
        gameObject.SetActive(false);
    }

    /*TOGGLE
      Switches the menu between open and closed states
    */
    public void Toggle()
    {
        if(isOpen) Close();
        else Open();
    }
}
