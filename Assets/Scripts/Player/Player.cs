using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Player
 * ------
 * Represents the player entity.
 * Coordinates core player systems including health, movement, modifiers, and view.
 */

public class Player : MonoBehaviour
{
    /*
     * REFERENCES
     * External systems required for health logic
     */
    public HealthSystem health;
    public PlayerMovement movement;
    public ModifierManager modifierManager;
    public PlayerView playerView;

    /*
     * UNITY METHODS
     * Handles the setup and event subscriptions for when the player is created.
     */
    private void Start()
    {
        if (health != null)
        {
            health.onDeath += Die;
        }
    }

    // Methods
    public void TakeDamage(int amount)
    {
        if (health != null)
        {
            health.TakeDamage(amount);
        }
    }    

    public void ApplyModifier(Modifier modifier)
    {
        if (modifierManager != null)
        {
            modifierManager.ApplyModifier(modifier);
        }
    }

    /* 
     * DEATH
     * Sends the player to the death screen when health reaches zero.
     * Death screen is just a placeholder for now.
     */
    public void Die()
    {
        SceneManager.LoadScene("DeathScreen");
    }
}
