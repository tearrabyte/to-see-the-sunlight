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

public enum HealthModifierType
{
    Shield,
}

public enum VisionModifierType
{
    Blindness,
    GlowwormLantern,
}

public enum EnvironmentModifierType
{
    MoreTime,
    FasterCold,
}

[System.Serializable]
public class Modifier
{
    public ModifierType type;
    public string description;

    public MovementModifierType movementModifierType;
    public VisionModifierType visionModifierType;
    public HealthModifierType healthModifierType;
    public EnvironmentModifierType environmentModifierType;

    public float effectValue;

    public bool isApplied;

    public Sprite icon;
}
