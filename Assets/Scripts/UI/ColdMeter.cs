using UnityEngine;
using UnityEngine.UI;

/*
 * COLD METER
 * Tracks the player's warmth. Only active during Level 2
 * Drains 1/8 per second, refills near campfire, deals damage when empty and starts over
 */
public class ColdMeter : MonoBehaviour
{

    //DrainTime is 8 seconds for full drain.
    //RefillSpeed is how fast it refills near campfire

    [SerializeField] private float drainTime = 8f;
    [SerializeField] private float refillSpeed = 0.5f;

    [SerializeField] private Image coldMeterImage;

    [SerializeField] private float warmthModifierMultiplier = 2f;
    [SerializeField] private float coldModifierMultiplier = 2f;

    //HealthSystem to call TakeDamage when cold meter empties

    private HealthSystem healthSystem;

   /* Variables
    * CurrentWarmth tracks value between 0 and 1
    * IsNearFire is set by Campfire when player is in range
    * IsActive controls whether the meter runs at all
    * IsDamaging prevents repeated damage while meter is empty
    */
    private float currentWarmth = 1f;
    public bool isNearFire = false;
    private bool isActive = false;
    private bool isDamaging = false;

    /*
     * AWAKE
     * Takes HealthSystem, hides HUD by default
     */
    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        if (coldMeterImage != null)
        {
            coldMeterImage.gameObject.SetActive(false);
        }
            
    }

    /*
     * ACTIVATE
     * Called when player enters Level 2
     * Shows HUD and starts the timer
     */
    public void Activate()
    {
        isActive = true;
        currentWarmth = 1f;
        if (coldMeterImage != null)
        {
            coldMeterImage.gameObject.SetActive(true);
        }
            
    }

    /*
     * DEACTIVATE
     * Called when cold meter should stop, hides HUD
     */
    public void Deactivate()
    {
        isActive = false;
        if (coldMeterImage != null)
        {
            coldMeterImage.gameObject.SetActive(false);
        }
            
    }

    /*
     * APPLY COLD MODIFIER
     * Makes drain faster
     */
    public void ApplyColdModifier()
    {
        drainTime /= coldModifierMultiplier;
    }

    /*
     * APPLY WARMTH MODIFIER
     * Gives more time without campfire
     */
    public void ApplyWarmthModifier()
    {
        drainTime *= warmthModifierMultiplier;
    }
    /*
     * TICK
     * Processes one frame of cold meter logic.
     * Accepts deltaTime so it can be called from tests.
     */
    public void Tick(float deltaTime)
    {
        if (!isActive) return;

        if (isNearFire)
        {
            currentWarmth += refillSpeed * deltaTime;
            isDamaging = false;
        }
        else
        {
            currentWarmth -= (1f / drainTime) * deltaTime;
        }

        currentWarmth = Mathf.Clamp01(currentWarmth);

        if (coldMeterImage != null)
            coldMeterImage.fillAmount = currentWarmth;

        if (currentWarmth <= 0f && !isDamaging)
        {
            isDamaging = true;
            TakeColdDamage();
        }
    }
    /*
     * UPDATE
     * Calls Tick with real delta time during gameplay
     */
    private void Update()
    {
        Tick(Time.deltaTime);
    }

    /*
     * TAKE COLD DAMAGE
     * Deals 1 damage and resets meter for another chance
     */
    private void TakeColdDamage()
    {
        if (healthSystem != null)
        {
            healthSystem.TakeDamage(1);
        }

        currentWarmth = 1f;
        isDamaging = false;
    }


    /*
    * SET WARMTH (for testing)
    * Allows tests to manually set warmth value
    */
    public void SetWarmth(float value)
    {
        currentWarmth = value;
    }

    /*
     * GET WARMTH (for testing)
     * Allows tests to read current warmth value
     */
    public float GetWarmth()
    {
        return currentWarmth;

    }
}