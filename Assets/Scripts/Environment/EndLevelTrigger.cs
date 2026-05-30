using UnityEngine;

/*
 * EndLevelTrigger
 * ---------------
 * Teleports the player to the specified location when they enter the trigger area.
 */
public class EndLevelTrigger : MonoBehaviour
{
    /*
     * REFERENCES
     * The location where the player will be teleported.
     */
    [SerializeField] private Transform teleportLocation;

    /*
     * TRIGGER ENTER
     * Teleports the player when they enter the trigger area.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
            }

            player.transform.position = teleportLocation.position;

        }
    }
}