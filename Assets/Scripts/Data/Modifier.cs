using UnityEngine;

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
