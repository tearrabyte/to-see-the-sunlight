using UnityEngine;

/*
 * Modifier
 * --------
 * Represents a gameplay modifier that can affect player attributes (e.g. movement, health)
 * Can be applied or removed from a player.
 */

/*
 * TYPES OF MODIFIERS
 * Categories of modifiers available in the game.
 */
public enum ModifierType
{
    Movement,
    Health,
    Vision,
    Environment
}

public enum MovementModifierType
{
    DoubleJump,
}

[System.Serializable]
public class Modifier
{
    public ModifierType type;
    public string description;

    public MovementModifierType movementModifierType;

    public float effectValue;

    public bool isApplied;

    public Sprite icon;
}
