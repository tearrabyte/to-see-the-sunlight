using NUnit.Framework;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlowwormCavePlayerVisionTests
{
    private GameObject playerObject;
    private PlayerView view;
    private PlayerMovement movement;
    private PlayerData data;
    private Light2D light;

    /*
    * SETUP
    * Creates a minimal player object with required vision dependencies.
    */
    [SetUp]
    public void Setup()
    {
        playerObject = new GameObject();

        view = playerObject.AddComponent<PlayerView>();
        movement = playerObject.AddComponent<PlayerMovement>();

        light = new GameObject("Vision Light").AddComponent<Light2D>();
        light.transform.SetParent(playerObject.transform);
        view.visionLight = light;

        data = ScriptableObject.CreateInstance<PlayerData>();
        movement.data = data;

        view.movement = movement;
    }

    /*
    * TEARDOWN
    * Cleans up test objects after each test run.
    */
    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(playerObject);
        Object.DestroyImmediate(data);
    }

    /*
    * VISION  RADIUS LOGIC
    * Validates that vision radius is applied correctly based on modifier or lack-thereof.
    */
    [Test]
    public void RestoreDefaultVision_SetsCorrectValues()
    {
        data.defaultVisionRadius = 2f;

        view.RestoreDefaultVision();

        Assert.That(light.transform.localScale, Is.EqualTo(Vector3.one * 2f));
    }

    [Test]
    public void BlindnessModifier_SetsReducedVisionRadius()
    {
        data.blindnessVisionRadius = 0.8f;

        view.ApplyVisionModifier(VisionModifierType.Blindness);

        Assert.That(light.transform.localScale, Is.EqualTo(Vector3.one * 0.8f));
    }

    [Test]
    public void LanternModifier_SetsIncreasedVisionRadius()
    {
        data.lanternVisionRadius = 4f;

        view.ApplyVisionModifier(VisionModifierType.GlowwormLantern);

        Assert.That(light.transform.localScale, Is.EqualTo(Vector3.one * 4f));
    }
}
