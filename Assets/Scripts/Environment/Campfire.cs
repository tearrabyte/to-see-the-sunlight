using UnityEngine;

/*
 * CAMPFIRE
 * Detects player entering and exiting warmth zone.
 * Tells ColdMeter to refill while player is nearby.
 */
public class Campfire : MonoBehaviour
{
    /*
     * ON TRIGGER ENTER
     * Player enters warmth zone, starts refilling.
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ColdMeter coldMeter = other.GetComponent<ColdMeter>();
            if (coldMeter != null)
            {
                coldMeter.isNearFire = true;
            }
                
        }
    }

    /*
     * ON TRIGGER EXIT
     * Player leaves warmth zone, stops refilling.
     */
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ColdMeter coldMeter = other.GetComponent<ColdMeter>();
            if (coldMeter != null)
            {
                coldMeter.isNearFire = false;
            }
        }
                
    }
}
