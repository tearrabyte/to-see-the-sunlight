using UnityEngine;
using UnityEngine.Rendering.Universal;

/*
 * GlowwormCaveMechanic
 * --------------------
 * Handles environmental darkness for the Glowworm Cave biome.
 */

public class GlowwormCaveMechanic : BiomeMechanic
{
    /* 
     * REFERENCES
     * Visual systems and objects required for biome rendering.
     */
    [Header("References")]
    public Light2D globalDarknessLight;

    /* 
     * ACTIVATE
     * Enables biome darkness.
     */
    public override void Activate()
    {
        base.Activate();

        if (globalDarknessLight != null)
        {
            globalDarknessLight.enabled = true;
        }
    }

    /* 
     * DEACTIVATE
     * Disables biome darkness.
     */
    public override void Deactivate()
    {
        base.Deactivate();

        if(globalDarknessLight !=null)
        {
            globalDarknessLight.enabled = false;
        }
    }
}
