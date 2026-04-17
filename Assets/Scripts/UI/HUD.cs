using UnityEngine;

/*
 * HUD
 * ---
 * Displays real-time gameplay information for the player including health, a level timer, and active modifiers.
 * Updates dynamically based on system events.
 */

public class HUD : MonoBehaviour
{
    // Variables
    public Timer timer;
    public HealthSystem healthSystem;
    public ModifierManager modifierManager;

    // Methods
    public void UpdateHealthDisplay()
    {
        //TODO: Read healthSystem.currentHealth
    }

    public void UpdateTimerDisplay()
    {
        // TODO: Read timer.currentTime
    }

    public void UpdateModifierDisplay()
    {
        // TODO: Read modifierManager.GetActiveModifiers()
    }
}
