using NUnit.Framework;
using UnityEngine;

public class PlayerDoubleJumpTests
{
    /*
    * DOUBLE JUMP
    * Validates modifier-driven air jump behaviour.
    */

    [Test]
    public void Player_Cannot_AirJump_When_No_Modifier()
    {
        var player = new GameObject();

        var movement = player.AddComponent<PlayerMovement>();

        Assert.AreEqual(0, movement.MaxAirJumps);

        Object.DestroyImmediate(player);
    }

    [Test]
    public void Player_Can_AirJump_When_Modifier_Enabled()
    {
        var player = new GameObject();

        var movement = player.AddComponent<PlayerMovement>();
        var manager = player.AddComponent<ModifierManager>();

        Modifier modifier = new Modifier
        {
            type = ModifierType.Movement,
            movementModifierType = MovementModifierType.DoubleJump
        };

        manager.ApplyModifier(modifier);

        Assert.AreEqual(1, movement.MaxAirJumps);

        Object.DestroyImmediate(player);
    }

    [Test]
    public void AirJump_Is_Consumed_On_Use()
    {
        var player = new GameObject();

        var movement = player.AddComponent<PlayerMovement>();

        movement.EnableDoubleJump();
        movement.UseAirJump();

        Assert.AreEqual(0, movement.AirJumpsRemaining);

        Object.DestroyImmediate(player);
    }

    [Test]
    public void Player_Cannot_AirJump_When_None_Remain()
    {
        var player = new GameObject();

        var movement = player.AddComponent<PlayerMovement>();

        movement.EnableDoubleJump();
        movement.UseAirJump();

        bool canUseAirJump = movement.CanUseAirJump();

        Assert.IsFalse(canUseAirJump);

        Object.DestroyImmediate(player);
    }

    [Test]
    public void Landing_Resets_Air_Jumps()
    {
        var player = new GameObject();

        var movement = player.AddComponent<PlayerMovement>();

        movement.EnableDoubleJump();
        movement.UseAirJump();

        movement.ResetAirJumps();
        Assert.AreEqual(1, movement.AirJumpsRemaining);

        Object.DestroyImmediate(player);
    }

    [Test]
    public void AirJump_Cannot_Be_Used_Infinitely()
    {
        var player = new GameObject();

        var movement = player.AddComponent<PlayerMovement>();

        movement.EnableDoubleJump();
        movement.UseAirJump();

        movement.UseAirJump();

        Assert.AreEqual(0, movement.AirJumpsRemaining);

        Object.DestroyImmediate(player);
    }
}
