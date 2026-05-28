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
                PlayerMovement movement = GetComponent<PlayerMovement>();

                if(modifier.movementModifierType == MovementModifierType.DoubleJump)
                {
                    movement.EnableDoubleJump();
                }
            }
            
            // Vision Modifiers
            if(modifier.type == ModifierType.Vision)
            {
                PlayerView view = GetComponent<PlayerView>();

                if(modifier.visionModifierType == VisionModifierType.Blindness)
                {
                    view.UpdateVisionRadius(player.movement.data.reducedVisionRadius);
                }
                else if(modifier.visionModifierType== VisionModifierType.GlowwormLantern)
                {
                    view.UpdateVisionRadius(player.movement.data.increasedVisionRadius);
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
            onModifiersChanged?.Invoke();

            if(modifier.type == ModifierType.Vision)
            {
                PlayerView view = GetComponent<PlayerView>();

                view.UpdateVisionRadius(player.movement.data.defaultVisionRadius);
            }
        }
    }

    public void UpdateModifiers()
    {

    }
}
