using UnityEngine;

/*
 * PlayerData
 * --------------
 * Stores all tunable movement parameters for the player.
 * Used by PlayerMovement to determine movement feel and behaviour.
 */

[CreateAssetMenu(menuName = "Player/Player Data")]
public class PlayerData : ScriptableObject
{
    /* MOVEMENT
     * Controls horizontal movement behaviour.
     */
    [Header("Movement")]
    public float maxSpeed = 10f;

    public float groundAcceleration = 50f;
    public float groundDeceleration = 50f;

    public float airAcceleration = 30f;
    public float airDeceleration = 20f;

    /* JUMP
     * Outlines upward force applied during the jump action.
     */
    [Header("Jump")]
    public float jumpForce = 12f;

    /*
     * GRAVITY
     * Controls fall behaviour and maximum fall speed.
     */
    [Header("Gravity")]
    public float gravityScale = 3f;
    public float maxFallSpeed = 20f;
}
