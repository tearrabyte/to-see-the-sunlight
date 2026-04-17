using System.Collections.Generic;
using UnityEngine;

/*
 * PlayerView
 * -----------
 * Manages the visual representation of the player including sprite rendering and visual effects.
 * Controls vision-related properties such as a limited vision radius.
 */

public class PlayerView : MonoBehaviour
{
    // Variables
    public SpriteRenderer spriteRenderer;
    public List<Modifier> currentEffects = new List<Modifier>();
    public Player player;
    public float visionRadius;

    // Methods
    public void UpdateVisualEffects()
    {

    }

    public void ApplyEffect(Modifier modifier)
    {

    }

    public void RemoveEffect(Modifier modifier)
    {

    }

    public void UpdateVisionRadius()
    {

    }
}
