using System;
using System.Collections.Generic;
using UnityEngine;

/*
 * ModifierManager
 * ---------------
 * Manages all active modifiers applied to the player.
 * Handles the application, removal and updating of modifier effects.
 */

public class ModifierManager : MonoBehaviour
{
    /* 
     * REFERENCES
     * External systems affected by modifiers
     */
    public Player player;
    private PlayerMovement _playerMovement;
    private PlayerView _playerView;
    private HealthSystem _healthSystem;

    /* 
     * STATE
     * Runtime collection of currently active modifiers
     */
    public List<Modifier> activeModifiers = new List<Modifier>();


    /* 
     * EVENTS
     * Invoked whenever modifier state changes.
     */
    public Action onModifiersChanged;


    /* 
     * AWAKE
     * Required player component references.
     */
    private void Awake()
    {
        if (player == null)
        {
            player = GetComponent<Player>();
        }

        _playerMovement = GetComponent<PlayerMovement>();
        _playerView = GetComponent<PlayerView>();
        _healthSystem = GetComponent<HealthSystem>();
    }

    /* 
     * ACTIVE MODIFIERS
     * Returns all currently active modifiers.
     */
    public List<Modifier> GetActiveModifiers()
    {
        return activeModifiers;
    }


    /* 
     * APPLY MODIFIER
     * Adds a modifier and applies its gameplay effect
     */
    public void ApplyModifier(Modifier modifier)
    {
        if(modifier != null)
        {
            activeModifiers.Add(modifier);

            // Movement Modifiers
            if(modifier.type == ModifierType.Movement)
            {
                if(modifier.movementModifierType == MovementModifierType.DoubleJump)
                {
                    if (_playerMovement == null)
                    {
                        _playerMovement = GetComponent<PlayerMovement>();
                    }
                    _playerMovement.EnableDoubleJump();
                }
            }
            
            // Vision Modifiers
            if(modifier.type == ModifierType.Vision)
            {
                _playerView.ApplyVisionModifier(modifier.visionModifierType);
            }

            // Health Modifiers
            if(modifier.type == ModifierType.Health)
            {
                if(modifier.healthModifierType == HealthModifierType.Shield)
                {
                    _healthSystem.EnableShield();
                }
            }

            onModifiersChanged?.Invoke();
        }
    }


    /* 
     * REMOVE MODIFIER
     * Removes a modifier from the active modifier list.
     */
    public void RemoveModifier(Modifier modifier)
    {
        if (modifier != null)
        {
            activeModifiers.Remove(modifier);

            if(modifier.type == ModifierType.Vision)
            {
                _playerView.RestoreDefaultVision();
            }

            onModifiersChanged?.Invoke();
        }
    }
}
