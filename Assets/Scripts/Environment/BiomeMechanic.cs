using UnityEngine;

/*
 * BiomeMechanic
 * -------------
 * Base class for biome-specific environmental behaviour.
 * Handles activation lifecycle.
 */

public abstract class BiomeMechanic : MonoBehaviour
{
    protected bool isActive;

    public virtual void Activate()
    {
        isActive = true;
    }

    public virtual void Deactivate()
    {
        isActive = false;
    }
}