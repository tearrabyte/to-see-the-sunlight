using UnityEngine;

/*
 * SpikeHazard
 * -----------
 * Damages the player when they enter the spike hazard trigger area.
 */

public class SpikeHazard : Hazard
{

    /*
     * UNITY METHODS
     * Activates the spike hazard when gameplay starts.
     */
    private void Start()
    {
        Activate();
    }

    /*
     * TRIGGER ENTER
     * Applies the spike effect when the player enters the trigger area.
     */
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isActive)
        {
            return;
        }

        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            ApplyEffect(player);
        }
    }

    /*
     * APPLY EFFECT
     * Deals one damage to the player
     */
    public override void ApplyEffect(Player player)
    {
        player.TakeDamage(1);
    }
}