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

[System.Serializable]
public class Modifier
{
    public string name;
    public string description;
    public ModifierType type;

    public float effectValue;

    public bool isApplied;
}
