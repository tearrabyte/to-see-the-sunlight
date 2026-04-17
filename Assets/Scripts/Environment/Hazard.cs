using UnityEngine;

/*
 * Hazard
 * ------
 * Represents an environmental hazard that can damage or affect the player.
 */

public abstract class Hazard : MonoBehaviour
{
    // Variables
    protected bool isActive;

    // Methods
    public virtual void Activate()
        // Use virtual so child classes may override the default behaviour if necessary.
    {
        isActive = true;
    }

    public virtual void Deactivate()
    {
        isActive = false;
    }

    public abstract void ApplyEffect(Player player);
}
