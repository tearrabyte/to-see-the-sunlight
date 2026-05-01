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
    [Range(5.0f, 20.0f)] public float maxSpeed = 7.0f;

    [Space(5)]

    [Range(10.0f, 50.0f)] public float groundAcceleration = 25.0f;
    [Range(10.0f, 50.0f)] public float groundDeceleration = 25.0f;

    [Space(5)]

    [Range(10.0f, 50.0f)] public float airAcceleration = 15.0f;
    [Range(10.0f, 50.0f)] public float airDeceleration = 10.0f;

    /* 
     * JUMP
     * Defines upward force and jump responsiveness parameters.
     */
    [Header("Jump")]
    [Range(0.0f, 10.0f)] public float jumpHeight = 6.5f;
    /* 
     * ASSISTS
     * Movement forgiveness system (jump buffer + coyote time)
     */
    [Header("Assists")]
    [Range(0.01f, 0.5f)] public float jumpBufferTime = 0.075f;
    [Range(0.01f, 0.5f)] public float coyoteTime = 0.05f;

    /*
     * GRAVITY
     * Controls fall behaviour and maximum fall speed.
     */
    [Header("Gravity")]
    [Range(1.0f, 5.0f)] public float gravityScale = 3.0f;

    [Space(5)]

    public float maxFallSpeed = 20f;

    [Space(5)]

    [Range(1.0f, 5.0f)] public float jumpCutGravityMultiplier = 3.0f;
    [Range(1.0f, 3.0f)] public float fallGravityMultiplier = 2.5f;

    [Space(5)]

    [Range(0.0f, 0.3f)] public float apexThreshold = 0.15f;
    [Range(0.5f, 1.0f)] public float apexGravityMultiplier = 0.5f;
}
