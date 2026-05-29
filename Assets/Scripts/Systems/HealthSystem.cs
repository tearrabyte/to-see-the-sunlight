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
    // Variables
    [SerializeField] private int maxHealth = 3;

    public int currentHealth;
    public int MaxHealth => maxHealth;

    public AudioManager audioManager;

    // Events
    public Action onHealthChanged;
    public Action onDeath;


    // Unity Methods
    void Start()
    {
        InitialiseHealth();
    }
    
    /*
     * INITIALIZE HEALTH
     * Sets current health to the maximum health value.
     */
    public void InitialiseHealth()
    {
        currentHealth = maxHealth;
        onHealthChanged?.Invoke();
    }

    /*
     * DAMAGE
     * Reduces players health and triggers death when health reaches to zero.
     */
    public void TakeDamage(int amount)
    {
        if (!isAlive())
        {
            return;
        }

        currentHealth -= amount;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        onHealthChanged?.Invoke();

        if (currentHealth <= 0)
        {
            onDeath?.Invoke();
        }    
    }
    
    /*
     * HEALING
     * Restores health without exceeding the maximum heath limit.
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
    public bool isAlive()
    {
        return currentHealth > 0;
    }
}