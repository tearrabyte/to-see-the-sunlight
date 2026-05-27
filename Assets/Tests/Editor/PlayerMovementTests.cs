using NUnit.Framework;
using UnityEngine;

public class PlayerMovementLogicTests
{
    /*
    * JUMP LOGIC
    * Validates jump eligibility rules based on buffer and coyote time values.
    */

    [Test]
    public void Jump_Is_Allowed_When_Buffer_And_Coyote_Valid()
    {
        var movement = new PlayerMovement();

        bool result = movement.CanJumpTest(0.1f, 0.1f);

        Assert.IsTrue(result);
    }

    [Test]
    public void Jump_Is_Not_Allowed_When_No_Buffer()
    {
        var movement = new PlayerMovement();

        bool result = movement.CanJumpTest(0f, 0.1f);

        Assert.IsFalse(result);
    }

    [Test]
    public void Can_Jump_Is_False_When_Both_Zero()
    {
        var movement = new PlayerMovement();

        bool result = movement.CanJumpTest(0f, 0f);

        Assert.IsFalse(result);
    }

    /*
    * MOVEMENT SPEED
    * Validates conversion from input value to target movement speed.
    */

    [Test]
    public void TargetSpeed_Is_Calculated_Correctly()
    {
        var movement = new PlayerMovement();

        float speed = movement.TargetSpeedTest(1f, 7f);

        Assert.AreEqual(7f, speed);
    }

    [Test]
    public void TargetSpeed_Is_Negative_When_Input_Negative()
    {
        var movement = new PlayerMovement();

        float speed = movement.TargetSpeedTest(-1f, 7f);

        Assert.AreEqual(-7f, speed);
    }
}