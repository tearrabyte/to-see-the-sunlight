using UnityEngine;

/*
 * Player
 * ------
 * Represents the player entity.
 * Coordinates core player systems including health, movement, modifiers, and view.
 */

public class Player : MonoBehaviour
{
    // Variables
    public HealthSystem health;
    public PlayerMovement movement;
    public ModifierManager modifierManager;
    public PlayerView playerView;

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

    public void Die()
    {

    }
}
