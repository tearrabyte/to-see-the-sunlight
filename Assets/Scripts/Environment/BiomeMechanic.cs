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

    /* 
     * ACTIVATE
     * Called when biome becomes active (player enters).
     */
    public virtual void Activate()
    {
        isActive = true;
    }

    /* 
     * DEACTIVATE
     * Called when biome is no longer active (player exits).
     */
    public virtual void Deactivate()
    {
        isActive = false;
    }
}