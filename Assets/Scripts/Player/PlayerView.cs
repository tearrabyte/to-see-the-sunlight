using UnityEngine;
using UnityEngine.Rendering.Universal;

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
     * VISION
     * Controls player visibility in different biome environments.
     */
    [Header("Vision")]
    public Light2D visionLight;

    private float _baseVisionRadius;
    private float _currentFlickerAmount;
    private float _currentFlickerSpeed;

    /* 
     * START
     * Initialises player visual systems.
     */
    private void Start()
    {
        InitialiseVision();
    }

    /* 
     * UPDATE
     * Updates runtime visual systems each frame.
     */
    private void Update()
    {
        UpdateAnimations();
        UpdateFacing();
        UpdateVisionFlicker();
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


    /* 
     * INITIALISE VISION
     * Initialises the default player vision state.
     */
    private void InitialiseVision()
    {
        if (movement == null || movement.data == null || visionLight == null) return;

        RestoreDefaultVision();
    }

    /* 
     * ENABLE VISION
     * Enables the player vision light.
     */
    public void EnableVision()
    {
        if (visionLight != null)
        {
            visionLight.enabled = true;
        }
    }

    /* 
     * DISABLE VISION
     * Disables the player vision light.
     */
    public void DisableVision()
    {
        if(visionLight != null)
        {
            visionLight.enabled = false;
        }
    }

    /* 
    * APPLY VISION MODIFIER
    * Applies runtime vision behaviour based on modifier state.
    */
    public void ApplyVisionModifier(VisionModifierType modifierType)
    {
        switch(modifierType)
        {
            case VisionModifierType.Blindness:
                UpdateVisionRadius(
                    movement.data.blindnessVisionRadius,
                    movement.data.blindnessFlickerAmount,
                    movement.data.blindnessFlickerSpeed);
                break;

            case VisionModifierType.GlowwormLantern:
                UpdateVisionRadius(
                    movement.data.lanternVisionRadius,
                    movement.data.lanternFlickerAmount,
                    movement.data.lanternFlickerSpeed);
                break;
        }
    }

    /* 
    * RESTORE DEFAULT VISION
    * Restores the default biome vision state.
    */
    public void RestoreDefaultVision()
    {
        UpdateVisionRadius(
            movement.data.defaultVisionRadius,
            movement.data.defaultFlickerAmount,
            movement.data.defaultFlickerSpeed);
    }

    /* 
    * UPDATE VISION
    * Updates player vision radius and flicker behaviour.
    */
    public void UpdateVisionRadius(float radius, float flickerAmount, float flickerSpeed)
    {
        if(visionLight == null) return;

        _baseVisionRadius = radius;

        _currentFlickerAmount = flickerAmount;
        _currentFlickerSpeed = flickerSpeed;

        visionLight.transform.localScale = Vector3.one * radius;
    }

    /* 
    * VISION FLICKER
    * Applies atmospheric fluctuation to the player vision radius.
    */
    private void UpdateVisionFlicker()
    {
        if (visionLight == null) return;

        if (_currentFlickerAmount <= 0f)
        {
            visionLight.transform.localScale = Vector3.one * _baseVisionRadius;
            return;
        }

        float flicker = Mathf.Sin(Time.time * _currentFlickerSpeed) * _currentFlickerAmount;
        float clampFlicker = Mathf.Max(0.25f, _baseVisionRadius + flicker);

        visionLight.transform.localScale = Vector3.one * clampFlicker;
    }

}
