using NUnit.Framework;
using UnityEngine;

public class ColdMeterTests
{
    /*
     TEST 1 - COLD METER DECREASES WARMTH WHEN NOT NEAR FIRE
     When the player remains in a cold biome without heat sources,
     the cold meter gradually fills up
     */
    [Test]
    public void ColdMeter_DecreasesWarmth_WhenNotNearFire()
    {
        var playerGO = new GameObject();
        playerGO.AddComponent<HealthSystem>();
        var coldMeter = playerGO.AddComponent<ColdMeter>();
        coldMeter.Activate();
        coldMeter.isNearFire = false;
        coldMeter.SetWarmth(1f);

        coldMeter.Tick(2f);

        Assert.Less(coldMeter.GetWarmth(), 1f);
    }

    /*
     TEST 2 - CAMPFIRE INCREASES WARMTH WHEN NEAR FIRE
     When the player stands near a campfire,
     the cold meter decreases
     */
    [Test]
    public void ColdMeter_IncreasesWarmth_WhenNearFire()
    {
        var playerGO = new GameObject();
        playerGO.AddComponent<HealthSystem>();
        var coldMeter = playerGO.AddComponent<ColdMeter>();
        coldMeter.Activate();
        coldMeter.isNearFire = false;
        coldMeter.SetWarmth(0.3f);

        coldMeter.isNearFire = true;
        coldMeter.Tick(2f);

        Assert.Greater(coldMeter.GetWarmth(), 0.3f);
    }
}