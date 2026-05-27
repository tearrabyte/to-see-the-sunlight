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

}
