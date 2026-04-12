using UnityEngine;

public abstract class BiomeMechanic : MonoBehaviour
{
    // Variables
    protected Level level;
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

    public virtual void UpdateEffect(Player player)
    {

    }
}
