using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // Variables
    public int currentHealth;
    public int maxHealth;

    public AudioManager audioManager;

    // Events
    public Action onHealthChanged;
    public Action onDeath;


    // Unity Methods
    void Start()
    {
        // Initial Setup
        currentHealth = maxHealth;
    }
    // Methods
    public void TakeDamage(int amount)
    {
    
    }
    
    public void Heal(int amount)
    {

    }

    public bool isAlive()
    {
        return currentHealth > 0;
    }
}
