using UnityEngine;

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
