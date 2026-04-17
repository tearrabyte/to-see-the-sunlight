using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

/*
 * ModifierManager
 * ---------------
 * Manages all active modifiers applied to the player.
 * Handles the application, removal and updating of modifier effects.
 */

public class ModifierManager : MonoBehaviour
{
    // Variables
    public List<Modifier> activeModifiers = new List<Modifier>();
    public Player player;

    // Events
    public Action onModifiersChanged;

    // Methods
    public List<Modifier> GetActiveModifiers()
    {
        return activeModifiers;
    }

    public void ApplyModifier(Modifier modifier)
    {
        if(modifier != null)
        {
            activeModifiers.Add(modifier);

            // Route to correct method based on type.

            onModifiersChanged?.Invoke();
        }
    }    
    
    public void RemoveModifier(Modifier modifier)
    {
        if (modifier != null)
        {
            activeModifiers.Remove(modifier);
            onModifiersChanged?.Invoke();
        }
    }

    public void UpdateModifiers()
    {

    }
}
