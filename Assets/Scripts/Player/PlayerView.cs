using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

/*
 * PlayerView
 * -----------
 * Manages the visual representation of the player including sprite rendering and visual effects.
 * Controls vision-related properties such as a limited vision radius.
 */

public class PlayerView : MonoBehaviour
{
    /* 
     * REFERENCES
     * Visual and gameplay systems required for player rendering and animation
     */
    [Header("References")]
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public PlayerMovement movement;


    /* 
     * VISUAL EFFECTS
     * Runtime modifier-driven visual effects.
     */
    [Header("Effects")]
    public List<Modifier> currentEffects = new List<Modifier>();


    /* 
     * VISION
     * Controls player visibility in different biome environments.
     */
    [Header("Vision")]
    public float visionRadius;


    private void Update()
    {
        UpdateAnimations();
        UpdateFacing();
    }


    /* 
     * ANIMATION
     * Updates animator parameters based on movement state.
     */
    public void UpdateAnimations()
    {
        if (movement == null || animator == null) return;

        float speed = Mathf.Abs(movement.Velocity.x);

        animator.SetFloat("Speed", speed);
        animator.SetBool("IsGrounded", movement.IsGrounded);
        animator.SetBool("IsJumping", movement.IsJumping);
        animator.SetBool("IsFalling", movement.IsFalling);
    }

    /* 
     * FACING
     * Handles sprite orientation based on movement direction.
     */
    public void UpdateFacing()
    {
        if (movement == null || spriteRenderer == null) return;

        spriteRenderer.flipX = movement.IsFacingRight;
    }

    public void UpdateVisualEffects()
    {

    }

    public void ApplyEffect(Modifier modifier)
    {

    }

    public void RemoveEffect(Modifier modifier)
    {

    }

    public void UpdateVisionRadius()
    {

    }
}
