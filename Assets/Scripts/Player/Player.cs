using UnityEngine;

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
