using UnityEngine;

[CreateAssetMenu(menuName = "Player/Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Movement")]
    public float maxSpeed = 10f;

    public float groundAcceleration = 50f;
    public float groundDeceleration = 50f;

    public float airAcceleration = 30f;
    public float airDeceleration = 20f;

    [Header("Jump")]
    public float jumpForce = 12f;

    [Header("Gravity")]
    public float gravityScale = 3f;
    public float maxFallSpeed = 20f;
}
