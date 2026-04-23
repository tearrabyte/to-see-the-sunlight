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

    
    // Methods

    // Sets the menu state to open and activates the UI object.
    
    // This also activates the menu game object.
    public virtual void Open()
    {
        isOpen = true;
        gameObject.SetActive(true);
    }

    // Sets the menu state to closed and deactivates the UI object

    // // This also deactivates the menu game object.
    public virtual void Close()
    {
        isOpen = false;
        gameObject.SetActive(false);
    }

    // Toggles the current active state of the menu.
    public void Toggle()
    {
        if(isOpen) Close();
        else Open();
    }
}
