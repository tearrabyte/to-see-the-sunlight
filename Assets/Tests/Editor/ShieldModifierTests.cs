using UnityEngine;
using NUnit.Framework;

public class ShieldModifierTests
{
    [Test]
    public void Shield_Adds_Extra_Health()
    {
        GameObject player = new GameObject();
        HealthSystem healthSystem = player.AddComponent<HealthSystem>();

        healthSystem.InitialiseHealth();
        healthSystem.EnableShield();

        Assert.AreEqual(4, healthSystem.currentHealth);
        Assert.IsTrue(healthSystem.HasShield);

        Object.DestroyImmediate(player);
    }

    [Test]
    public void Shield_Is_Removed_When_Extra_Health_Is_Lost()
    {
        GameObject player = new GameObject();
        HealthSystem healthSystem = player.AddComponent<HealthSystem>();

        healthSystem.InitialiseHealth();
        healthSystem.EnableShield();

        healthSystem.TakeDamage(1);

        Assert.AreEqual(3, healthSystem.currentHealth);
        Assert.IsFalse(healthSystem.HasShield);

        Object.DestroyImmediate(player);
    }
}
