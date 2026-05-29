using UnityEngine;
using UnityEngine.UI;

/*
 * HUD
 * ---
 * Displays real-time gameplay information for the player including health, a level timer, and active modifiers.
 * Updates dynamically based on system events.
 */

public class HUD : MonoBehaviour
{
    /*
     * REFERENCES
     * Core gameplay systems and IU elements used by the HUD.
     */
    public Timer timer;
    public HealthSystem healthSystem;
    public ModifierManager modifierManager;

    [SerializeField] private Image[] heartImages;

    /*
     * UNITY METHODS
     * Subscribes to health events and updates the display when the HUD starts.
     */
    private void Start()
    {
        if (healthSystem != null)
        {
            healthSystem.onHealthChanged += UpdateHealthDisplay;
            UpdateHealthDisplay();
        }
    }    

    // Methods

    /* 
     * UPDATE HEALTH DISPLAY
     * Shows or hides heart icons based on the player's current health.
     */
    public void UpdateHealthDisplay()
    {
        if (healthSystem == null)
        {
            return;
        }

        for (int i = 0; i < heartImages.Length; i++)
        {
            heartImages[i].enabled = i < healthSystem.currentHealth;
        }
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