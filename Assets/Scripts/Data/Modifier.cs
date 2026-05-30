using UnityEngine;

/*
 * Modifier
 * --------
 * Represents a gameplay modifier that can affect player attributes (e.g. movement, health)
 * Can be applied or removed from a player.
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

public enum VisionModifierType
{
    Blindness,
    GlowwormLantern,
}

[System.Serializable]
public class Modifier
{
    public ModifierType type;
    public string description;

    public MovementModifierType movementModifierType;
    public VisionModifierType visionModifierType;

    public float effectValue;

    public bool isApplied;
}
