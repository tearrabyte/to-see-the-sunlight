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
     * Core gameplay systems and UI elements used by the HUD.
     */
    public Timer timer;
    public HealthSystem healthSystem;
    public ModifierManager modifierManager;

    [SerializeField] private Image[] heartImages;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private Image shieldImage;

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
            if (i < healthSystem.currentHealth)
            {
                heartImages[i].sprite = fullHeart;
            }
            else
            {
                heartImages[i].sprite = emptyHeart;
            }
        }

        if (shieldImage != null)
        {
            shieldImage.enabled = healthSystem.HasShield;
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