using UnityEngine;

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
