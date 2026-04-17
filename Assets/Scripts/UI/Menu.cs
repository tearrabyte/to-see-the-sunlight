using UnityEngine;

/*
 * Menu
 * ----
 * Base class for all UI menus displayed outside of active gameplay.
 * Provides common functionality for opening, closing, and toggling UI panels.
 */

public class Menu : MonoBehaviour
{
    // Variables
    public bool isOpen;
    public string menuName;

    
    // Methods
    public virtual void Open()
    {
        isOpen = true;

    }

    public virtual void Close()
    {
        isOpen = false;

    }

    public void Toggle()
    {
        if(isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }
}
