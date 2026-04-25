using UnityEngine;

public class SpikeHazard : Hazard
{
    private void Start()
    {
        Activate();
    }
    private void OnTriggerEnter2D(Collider2D collision)
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
    public override void ApplyEffect(Player player)
    {
        player.TakeDamage(1);
    }
}