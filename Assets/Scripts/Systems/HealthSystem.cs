using System;
using UnityEngine;

/*
 * HealthSystem
 * ------------
 * Handles player health including damage, healing, and alive state.
 * Notifies other systems when health values change or when the player dies.
 */

public class HealthSystem : MonoBehaviour
{
    /*
     * VARIABLES
     * Stores the player's current and maximum health values.
     */
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float damageCooldown = 1f;
    private float nextDamageTime;

    private bool hasShield;
    public bool HasShield => hasShield;

    public int currentHealth;
    public int MaxHealth => maxHealth;

    public AudioManager audioManager;

    /*
     * EVENTS
     * Notifies the other systems when health changes or when the player dies.
     */
    public Action onHealthChanged;
    public Action onDeath;


    /*
     * UNITY METHODS
     * Initialises player health when gameplay starts.
     */
    void Start()
    {
        InitialiseHealth();
        EnableShield();
    }
    
    /*
     * INITIALISE HEALTH
     * Sets current health to the maximum health value.
     */
    public void InitialiseHealth()
    {
        currentHealth = maxHealth;
        onHealthChanged?.Invoke();
    }

    /*
     * ENABLE SHIELD
     * Grants the player an additional health.
     */
    public void EnableShield()
    {
        if (!hasShield)
        {
            hasShield = true;
            maxHealth += 1;
            currentHealth += 1;
            onHealthChanged?.Invoke();

        }
    }

    /*
     * DAMAGE
     * Reduces player health and triggers death when health reaches zero.
     */
    public void TakeDamage(int amount)
    {
        if (!IsAlive())
        {
            return;
        }

        if (Time.time < nextDamageTime)
        {
            return;
        }

        nextDamageTime = Time.time + damageCooldown;

        currentHealth -= amount;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (hasShield && currentHealth <= 3)
        {
            hasShield = false;
            maxHealth = 3;
        }

        onHealthChanged?.Invoke();

        if (currentHealth <= 0)
        {
            onDeath?.Invoke();
        }    
    }
    
    /*
     * HEALING
     * Restores health without exceeding the maximum health limit.
     */
    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        onHealthChanged?.Invoke();
    }

    /*
     * CHECK IF ALIVE
     * Returns whether the player still has any health remaining.
     */
    public bool IsAlive()
    {
        return currentHealth > 0;
    }
}