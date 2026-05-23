using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    // The location where the player will be teleported when they enter the trigger
    [SerializeField] private Transform teleportLocation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            // Gets the players Rigidbody2D component
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

            // Makes sure the players movement stops before teleporting
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
            }

            // Teleports the player to the start point of the next level
            player.transform.position = teleportLocation.position;

        }
    }
}