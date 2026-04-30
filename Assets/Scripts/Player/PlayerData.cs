using System.Runtime.CompilerServices;
using UnityEngine;

/*
 * PlayerData
 * --------------
 * Stores all tunable movement parameters for the player.
 * Used by PlayerMovement to control movement feel and responsiveness.
 */

[CreateAssetMenu(menuName = "Player/Player Data")]
public class PlayerData : ScriptableObject
{
    /*
     * MOVEMENT
     * Controls horizontal movement behaviour.
     */
    [Header("Movement")]
    public float maxSpeed = 10f;

    public float groundAcceleration = 50f;
    public float groundDeceleration = 50f;

    public float airAcceleration = 30f;
    public float airDeceleration = 20f;

    /* 
     * JUMP
     * Defines upward force and jump responsiveness parameters.
     */
    [Header("Jump")]
    public float jumpForce = 12f;

    /* 
     * ASSISTS
     * Movement forgiveness system (jump buffer + coyote time)
     */
    [Header("Assists")]
    [Range(0.01f, 0.5f)] public float jumpBufferTime = 0.075f;
    [Range(0.01f, 0.5f)] public float coyoteTime = 0.02f;

    /*
     * GRAVITY
     * Controls fall behaviour and maximum fall speed.
     */
    [Header("Gravity")]
    public float gravityScale = 3f;
    public float maxFallSpeed = 20f;
}
