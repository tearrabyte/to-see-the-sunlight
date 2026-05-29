using UnityEngine;
using NUnit.Framework;

public class HealthSystemTests
{
    [Test]
    public void Player_Starts_With_Three_Hearts()
    {
        GameObject player = new GameObject();
        HealthSystem health = player.AddComponent<HealthSystem>();
        health.InitialiseHealth();
        Assert.AreEqual(3, health.currentHealth);

        Object.DestroyImmediate(player);
    }

    [Test]
    public void Player_Loses_One_Health_When_Damaged()
    {
        GameObject player = new GameObject();
        HealthSystem health = player.AddComponent<HealthSystem>();
        health.InitialiseHealth();
        health.TakeDamage(1);
        Assert.AreEqual(2, health.currentHealth);

        Object.DestroyImmediate(player);
    }
}
