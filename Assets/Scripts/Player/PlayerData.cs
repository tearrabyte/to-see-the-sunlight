using UnityEngine;

[CreateAssetMenu(menuName = "Player/Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Movement")]
    public float moveSpeed = 10f;
    public float acceleration = 50f;
    public float deceleration = 50f;

    [Header("Jump")]
    public float jumpForce = 12f;

    [Header("Gravity")]
    public float gravityScale = 3f;
    public float maxFallSpeed = 20f;
}
